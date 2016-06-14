using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TOCManager.DataLayer.Infrastructure;
using TOCManager.DataLayer.Repositories;
using TOCManager.Entities;
using TOCManager.Membership;
using TOCManager.WebApi.Infrastructure.Core;
using TOCManager.WebApi.Infrastructure.Extensions;
using TOCManager.WebApi.Models;

namespace TOCManager.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Project> _projectsRepository;

        public ProjectsController(IEntityBaseRepository<Project> projectsRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _projectsRepository = projectsRepository;
        }

        public HttpResponseMessage Get(HttpRequestMessage request, string filter)
        {
            filter = filter.ToLower().Trim();

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var projects = _projectsRepository.GetAll()
                    .Where(p => p.Name.ToLower().Contains(filter)).ToList();

                var projectsVm = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projects);

                response = request.CreateResponse<IEnumerable<ProjectViewModel>>(HttpStatusCode.OK, projectsVm);

                return response;
            });
        }

        [Route("details/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var project = _projectsRepository.GetSingle(id);

                ProjectViewModel projectVm = Mapper.Map<Project, ProjectViewModel>(project);

                response = request.CreateResponse<ProjectViewModel>(HttpStatusCode.OK, projectVm);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, ProjectViewModel project)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                        ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                              .Select(m => m.ErrorMessage).ToArray());
                }
                else
                {
                    //if (_projectsRepository.UserExists(project.Email, project.IdentityCard))
                    //{
                    //    ModelState.AddModelError("Invalid user", "Email or Identity Card number already exists");
                    //    response = request.CreateResponse(HttpStatusCode.BadRequest,
                    //    ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                    //          .Select(m => m.ErrorMessage).ToArray());
                    //}
                    //else
                    //{
                    //}

                    Project newProject = new Project();
                    newProject.UpdateProject(project);
                    _projectsRepository.Add(newProject);
                    _unitOfWork.Commit();

                    UserProjectRole role = new UserProjectRole();
                    role.ProjectId = newProject.ID;
                    role.UserId = RequestContext.Principal.Identity.Name;
                    _userProjectRolesRepository.Add(role);
                    _unitOfWork.Commit();

                    // Update view model
                    project = Mapper.Map<Project, ProjectViewModel>(newProject);
                    response = request.CreateResponse<ProjectViewModel>(HttpStatusCode.Created, project);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, ProjectViewModel project)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                        ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                              .Select(m => m.ErrorMessage).ToArray());
                }
                else
                {
                    Project _project = _projectsRepository.GetSingle(project.ID);
                    _project.UpdateProject(project);

                    _unitOfWork.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }

        [HttpGet]
        [Route("search/{page:int=0}/{pageSize=4}/{filter?}")]
        public HttpResponseMessage Search(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                List<Project> projects = null;
                int totalProjects = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    filter = filter.Trim().ToLower();

                    projects = _projectsRepository.FindBy(p => p.Name.ToLower().Contains(filter))
                        .OrderBy(p => p.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalProjects = _projectsRepository.GetAll()
                        .Where(p => p.Name.ToLower().Contains(filter))
                        .Count();
                }
                else
                {
                    projects = _projectsRepository.GetAll()
                        .OrderBy(p => p.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                    .ToList();

                    totalProjects = _projectsRepository.GetAll().Count();
                }

                IEnumerable<ProjectViewModel> projectsVM = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projects);

                PaginationSet<ProjectViewModel> pagedSet = new PaginationSet<ProjectViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalProjects,
                    TotalPages = (int)Math.Ceiling((decimal)totalProjects / currentPageSize),
                    Items = projectsVM
                };

                response = request.CreateResponse<PaginationSet<ProjectViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }
    }
}
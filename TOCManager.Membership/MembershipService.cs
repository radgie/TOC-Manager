using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using TOCManager.DataLayer.Extensions;
using TOCManager.DataLayer.Infrastructure;
using TOCManager.DataLayer.Repositories;
using TOCManager.Entities;

namespace TOCManager.Membership
{
    public class MembershipService : IMembershipService
    {
        #region Variables
        private readonly IEntityBaseRepository<User> _userRepository;
        private readonly IEntityBaseRepository<ProjectRole> _projectRoleRepository;
        private readonly IEntityBaseRepository<Project> _projectRepository;
        private readonly IEntityBaseRepository<UserProjectRole> _userProjectRoleRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _unitOfWork;

        #endregion
        public MembershipService(IEntityBaseRepository<User> userRepository, IEntityBaseRepository<ProjectRole> projectRoleRepository,
        IEntityBaseRepository<UserProjectRole> userProjectRoleRepository, IEncryptionService encryptionService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _projectRoleRepository = projectRoleRepository;
            _userProjectRoleRepository = userProjectRoleRepository;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
        }

        #region IMembershipService Implementation

        public MembershipContext ValidateUser(string username, string password)
        {
            var membershipCtx = new MembershipContext();

            var user = _userRepository.GetSingleByUsername(username);
            if (user != null && isUserValid(user, password))
            {
                var userProjectRoles = GetUserAllProjectsRoles(user.Username);
                membershipCtx.User = user;

                var identity = new GenericIdentity(user.Username);
                membershipCtx.Principal = new GenericPrincipal(
                    identity,
                    userProjectRoles.Select(x => string.Format("{0}.{1}", x.ProjectId, x.Role.RoleName)).ToArray());
            }

            return membershipCtx;
        }
        public User CreateUser(string username, string password)
        {
            var existingUser = _userRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                throw new Exception("Username is already in use");
            }

            var passwordSalt = _encryptionService.CreateSalt();

            var user = new User()
            {
                Username = username,
                Salt = passwordSalt,
                IsLocked = false,
                HashedPassword = _encryptionService.EncryptPassword(password, passwordSalt),
                CreatedOn = DateTime.Now
            };

            _userRepository.Add(user);

            _unitOfWork.Commit();

            return user;
        }

        public User GetUser(int userId)
        {
            return _userRepository.GetSingle(userId);
        }

        public List<UserProjectRole> GetUserAllProjectsRoles(string username)
        {
            List<UserProjectRole> _result = new List<UserProjectRole>();

            var existingUser = _userRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                foreach (var userProjectRole in existingUser.UserProjectRoles)
                {
                    _result.Add(userProjectRole);
                }
            }

            return _result.Distinct().ToList();
        }

        public List<ProjectRole> GetUserProjectRoles(string username, int projectId)
        {
            List<ProjectRole> _result = new List<ProjectRole>();

            var existingUser = _userRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                foreach (var userProjectRole in existingUser.UserProjectRoles.Where(upr => upr.ProjectId == projectId))
                {
                    _result.Add(userProjectRole.Role);
                }
            }

            return _result.Distinct().ToList();
        }
        #endregion

        #region Helper methods
        private void addUserToProjectRole(User user, int projectId, int projectRoleId)
        {
            var project = _projectRepository.GetSingle(projectId);
            var role = _projectRoleRepository.GetSingle(projectRoleId);

            if (project == null)
            {
                throw new ApplicationException("Project doesn't exist.");
            }

            if (role == null)
            {
                throw new ApplicationException("Role doesn't exist.");
            }

            var userProjectRole = new UserProjectRole()
            {
                UserId = user.ID,
                ProjectId = project.ID,
                ProjectRoleId = role.ID
            };

            _userProjectRoleRepository.Add(userProjectRole);
        }

        private bool isPasswordValid(User user, string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword);
        }

        private bool isUserValid(User user, string password)
        {
            if (isPasswordValid(user, password))
            {
                return !user.IsLocked;
            }

            return false;
        }
        #endregion
    }
}

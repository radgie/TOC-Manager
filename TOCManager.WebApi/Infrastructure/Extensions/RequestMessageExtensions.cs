using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Dependencies;
using TOCManager.DataLayer.Repositories;
using TOCManager.Entities;
using TOCManager.Membership;

namespace TOCManager.WebApi.Infrastructure.Extensions
{
    public static class RequestMessageExtensions
    {
        internal static IMembershipService GetMembershipService(this HttpRequestMessage request)
        {
            return request.GetService<IMembershipService>();
        }

        internal static IEntityBaseRepository<T> GetDataRepository<T>(this HttpRequestMessage request) where T : class, IEntityBase, new()
        {
            return request.GetService<IEntityBaseRepository<T>>();
        }

        internal static IProjectsEntityBaseRepository<T> GetProjectsEntityDataRepository<T>(this HttpRequestMessage request) where T : class, IProjectsEntityBase, new()
        {
            return request.GetService<IProjectsEntityBaseRepository<T>>();
        }


        private static TService GetService<TService>(this HttpRequestMessage request)
        {
            IDependencyScope dependencyScope = request.GetDependencyScope();
            TService service = (TService)dependencyScope.GetService(typeof(TService));

            return service;
        }
    }
}
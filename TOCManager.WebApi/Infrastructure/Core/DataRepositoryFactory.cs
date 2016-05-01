using System.Net.Http;
using TOCManager.DataLayer.Repositories;
using TOCManager.Entities;
using TOCManager.WebApi.Infrastructure.Extensions;

namespace TOCManager.WebApi.Infrastructure.Core
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        public IEntityBaseRepository<T> GetDataRepository<T>(HttpRequestMessage request) where T : class, IEntityBase, new()
        {
            return request.GetDataRepository<T>();
        }
    }
}
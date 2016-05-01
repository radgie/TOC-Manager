using System.Net.Http;
using TOCManager.DataLayer.Repositories;
using TOCManager.Entities;

namespace TOCManager.WebApi.Infrastructure.Core
{
    public interface IDataRepositoryFactory
    {
        IEntityBaseRepository<T> GetDataRepository<T>(HttpRequestMessage request) where T : class, IEntityBase, new();
    }
}

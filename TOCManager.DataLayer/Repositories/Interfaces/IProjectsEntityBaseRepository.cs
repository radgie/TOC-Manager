using TOCManager.Entities;

namespace TOCManager.DataLayer.Repositories
{
    public interface IProjectsEntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IProjectsEntityBase, new()
    {
    }
}

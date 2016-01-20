using TOCManager.DataLayer.Infrastructure;
using TOCManager.Entities;

namespace TOCManager.DataLayer.Repositories
{
    public class ProjectsEntityBaseRepository<T> : EntityBaseRepository<T>, IEntityBaseRepository<T> where T : class, IProjectsEntityBase, new()
    {
        public ProjectsEntityBaseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

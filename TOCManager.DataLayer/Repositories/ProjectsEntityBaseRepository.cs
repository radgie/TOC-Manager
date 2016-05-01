using TOCManager.DataLayer.Infrastructure;
using TOCManager.Entities;

namespace TOCManager.DataLayer.Repositories
{
    public class ProjectsEntityBaseRepository<T> : EntityBaseRepository<T>, IProjectsEntityBaseRepository<T> where T : class, IProjectsEntityBase, new()
    {
        public ProjectsEntityBaseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

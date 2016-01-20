using TOCManager.Entities;

namespace TOCManager.DataLayer.Configurations
{
    public class ProjectsEntityBaseConfiguration<T> : EntityBaseConfiguration<T> where T : class, IProjectsEntityBase
    {
        public ProjectsEntityBaseConfiguration()
        {
            Property(pe => pe.ProjectId).IsRequired();
        }
    }
}

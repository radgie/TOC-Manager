using TOCManager.Entities;

namespace TOCManager.DataLayer.Configurations
{
    public class ProjectRoleConfiguration : EntityBaseConfiguration<ProjectRole>
    {
        public ProjectRoleConfiguration()
        {
            Property(pr => pr.RoleName).IsRequired().HasMaxLength(50);
        }
    }
}

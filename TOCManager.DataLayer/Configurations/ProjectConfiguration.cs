using TOCManager.Entities;

namespace TOCManager.DataLayer.Configurations
{
    public class ProjectConfiguration : EntityBaseConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(200);
            Property(p => p.OwnerId).IsRequired();
            Property(p => p.CreatedOn).IsRequired();
        }
    }
}

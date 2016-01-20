using TOCManager.Entities;

namespace TOCManager.DataLayer.Configurations
{
    public class UserProjectRoleConfiguration : ProjectsEntityBaseConfiguration<UserProjectRole>
    {
        public UserProjectRoleConfiguration()
        {
            Property(upr => upr.UserId).IsRequired();
            Property(upr => upr.ProjectRoleId).IsRequired();
        }
    }
}

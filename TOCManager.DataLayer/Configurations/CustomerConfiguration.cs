using TOCManager.Entities;

namespace TOCManager.DataLayer.Configurations
{
    public class CustomerConfiguration : ProjectsEntityBaseConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(c => c.Name).IsRequired().HasMaxLength(200);
            Property(c => c.Phone).HasMaxLength(15);
            Property(c => c.Email).HasMaxLength(200);
            Property(c => c.Address).IsRequired().HasMaxLength(500);
            Property(c => c.Description).HasMaxLength(4000);
        }
    }
}

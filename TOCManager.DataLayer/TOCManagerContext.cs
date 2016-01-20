using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TOCManager.DataLayer.Configurations;
using TOCManager.Entities;

namespace TOCManager.DataLayer
{
    public class TOCManagerContext : DbContext
    {
        public TOCManagerContext()
            : base("TOCManager")
        {
            Database.SetInitializer<TOCManagerContext>(null);
        }

        #region Entity Sets
        public IDbSet<User> UserSet { get; set; }
        public IDbSet<ProjectRole> ProjectRoleSet { get; set; }
        public IDbSet<Project> ProjectSet { get; set; }
        public IDbSet<UserProjectRole> UserProjectRoleSet { get; set; }
        public IDbSet<Customer> CustomerSet { get; set; }

        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ProjectRoleConfiguration());
            modelBuilder.Configurations.Add(new ProjectConfiguration());
            modelBuilder.Configurations.Add(new UserProjectRoleConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
        }
    }
}

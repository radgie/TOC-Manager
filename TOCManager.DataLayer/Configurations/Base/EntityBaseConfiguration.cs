using System.Data.Entity.ModelConfiguration;
using TOCManager.Entities;

namespace TOCManager.DataLayer.Configurations
{
    public class EntityBaseConfiguration<T> : EntityTypeConfiguration<T> where T : class, IEntityBase
    {
        public EntityBaseConfiguration()
        {
            HasKey(e => e.ID);
        }
    }
}

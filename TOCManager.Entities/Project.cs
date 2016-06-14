using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOCManager.Entities
{
    public class Project : IEntityBase
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int OwnerId { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<UserProjectRole> UserProjectRoles { get; set; }
    }
}

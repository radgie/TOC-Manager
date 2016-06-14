using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOCManager.Entities
{
    public class ProjectRole : IEntityBase
    {
        public int ID { get; set; }

        public string RoleName { get; set; }

        public virtual ICollection<UserProjectRole> UserProjectRoles { get; set; }
    }
}

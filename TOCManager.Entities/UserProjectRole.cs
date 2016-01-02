using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOCManager.Entities.Interfaces;

namespace TOCManager.Entities
{
    public class UserProjectRole : IEntityBase
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int ProjectID { get; set; }

        public int ProjectRoleID { get; set; }
    }
}

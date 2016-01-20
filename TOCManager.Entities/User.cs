using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOCManager.Entities
{
    /// <summary>
    /// User Account
    /// </summary>
    public class User : IEntityBase
    {
        public User()
        {
            UserProjectRoles = new List<UserProjectRole>();
        }

        public int ID { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string HashedPassword { get; set; }

        public string Salt { get; set; }

        public bool IsLocked { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<UserProjectRole> UserProjectRoles { get; set; }
    }
}

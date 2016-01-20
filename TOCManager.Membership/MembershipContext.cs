using System.Security.Principal;
using TOCManager.Entities;

namespace TOCManager.Membership
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }

        public User User { get; set; }

        public bool IsValid()
        {
            return Principal != null;
        }
    }
}

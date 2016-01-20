using System.Collections.Generic;
using TOCManager.Entities;

namespace TOCManager.Membership
{
    public interface IMembershipService
    {
        MembershipContext ValidateUser(string username, string password);

        User CreateUser(string username, string email, string password);

        User GetUser(int userId);

        List<ProjectRole> GetUserProjectRoles(string username, int projectId);
    }
}

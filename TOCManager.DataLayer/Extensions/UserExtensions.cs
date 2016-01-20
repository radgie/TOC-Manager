using System.Linq;
using TOCManager.DataLayer.Repositories;
using TOCManager.Entities;

namespace TOCManager.DataLayer.Extensions
{
    public static class UserExtensions
    {
        public static User GetSingleByUsername(this IEntityBaseRepository<User> userRepository, string username)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.Username == username);
        }
    }
}

using System.Collections.Generic;
using ProfileService.Models;

namespace ProfileService.Data
{
    public interface IUserRepo
    {
        public bool SaveChanges();

        IEnumerable<User> GetAllUsers();

        User GetUserById(int id);

        User GetUserByKeycloakIdentifier(string keyCloakIdentifier);

        void CreateUser(User user);

        bool ExternalUserExists(int externalUserId);
    }
}
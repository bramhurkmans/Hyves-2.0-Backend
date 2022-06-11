using System.Collections.Generic;
using KrabbelService.Models;

namespace KrabbelService.Data
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
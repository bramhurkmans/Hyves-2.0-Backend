using System.Collections.Generic;
using UserService.Models;

namespace UserService.Data
{
    public interface IUserRepo
    {
        public bool SaveChanges();

        IEnumerable<User> GetAllUsers();

        User GetUserByKeycloakIdentifier(string KeyCloakIdentifier);
        
        User GetUserById(int id);

        void CreateUser(User user);
    }
}
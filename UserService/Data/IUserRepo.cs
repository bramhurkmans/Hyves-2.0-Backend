using System.Collections.Generic;
using UserService.Models;

namespace UserService.Data
{
    public interface IUserRepo
    {
        public bool SaveChanges();

        IEnumerable<User> GetAllUsers();

        User GetUserById(int id);

        void CreateUser(User user);
    }
}
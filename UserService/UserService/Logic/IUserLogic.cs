using System.Collections.Generic;
using System.Security.Claims;
using UserService.Data;
using UserService.Models;

namespace UserService.Logic
{
    public interface IUserLogic
    {
        User GetUser(ClaimsPrincipal claimsPrincipal);

        User GetUser(int userId);

        IEnumerable<User> FindUsers(string query);
    }
}
using System.Security.Claims;
using UserService.Data;
using UserService.Models;

namespace UserService.Logic
{
    public interface IUserLogic
    {
        User GetUser(ClaimsPrincipal claimsPrincipal);
    }
}
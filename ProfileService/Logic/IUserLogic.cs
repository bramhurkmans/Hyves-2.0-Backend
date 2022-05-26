using ProfileService.Models;
using System.Security.Claims;

namespace ProfileService.Logic
{
    public interface IUserLogic
    {
        public User GetUser(ClaimsPrincipal claimsPrincipal);
    }
}

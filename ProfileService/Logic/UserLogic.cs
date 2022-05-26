using ProfileService.Data;
using ProfileService.Models;
using System.Security.Claims;

namespace ProfileService.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepo _userRepo;
        public UserLogic(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public User GetUser(ClaimsPrincipal claimsPrincipal)
        {
            return _userRepo.GetUserByKeycloakIdentifier(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}

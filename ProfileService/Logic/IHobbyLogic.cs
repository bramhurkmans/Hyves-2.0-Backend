using ProfileService.Models;
using System.Security.Claims;

namespace ProfileService.Logic
{
    public interface IHobbyLogic
    {
        public ICollection<Hobby> GetHobbies(ClaimsPrincipal claimsPrincipal, int profileId);

        public bool CreateHobby(ClaimsPrincipal claimsPrincipal, Hobby hobby);

        public bool DeleteHobby(ClaimsPrincipal claimsPrincipal, int hobbyId);
    }
}

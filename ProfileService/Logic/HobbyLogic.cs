using ProfileService.Data;
using ProfileService.Models;
using System.Security.Claims;

namespace ProfileService.Logic
{
    public class HobbyLogic : IHobbyLogic
    {
        private readonly IUserRepo _userRepo;
        private readonly IHobbyRepo _hobbyRepo;
        private readonly IProfileRepo _profileRepo;

        public HobbyLogic(IUserRepo userRepo, IHobbyRepo hobbyRepo, IProfileRepo profileRepo)
        {
            _userRepo = userRepo;
            _hobbyRepo = hobbyRepo;
            _profileRepo = profileRepo;
        }

        public bool CreateHobby(ClaimsPrincipal claimsPrincipal, Hobby hobby)
        {
            var user = _userRepo.GetUserByKeycloakIdentifier(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
            hobby.Profile = user.Profile;

            _hobbyRepo.CreateHobby(hobby);

            return _hobbyRepo.SaveChanges();
        }

        public bool DeleteHobby(ClaimsPrincipal claimsPrincipal, int hobbyId)
        {
            var user = _userRepo.GetUserByKeycloakIdentifier(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);

            if(user.Profile.Hobbies.Any(h => h.Id == hobbyId))
            {
                _hobbyRepo.RemoveHobby(hobbyId);
                return _hobbyRepo.SaveChanges();
            }

            return false;
        }

        public ICollection<Hobby> GetHobbies(ClaimsPrincipal claimsPrincipal, int profileId)
        {
            if(profileId == 0)
            {
                var authenticatedUser = _userRepo.GetUserByKeycloakIdentifier(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
                return authenticatedUser.Profile.Hobbies;
            }

            var profile = _profileRepo.GetProfileById(profileId);

            if (profile == null) return new List<Hobby>();

            return profile.Hobbies;
        }
    }
}

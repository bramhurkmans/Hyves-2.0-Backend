using ProfileService.Data;
using ProfileService.Models;
using System.Security.Claims;

namespace ProfileService.Logic
{
    public class SongLogic : ISongLogic
    {
        private readonly IUserRepo _userRepo;
        private readonly ISongRepo _songRepo;
        private readonly IProfileRepo _profileRepo;

        public SongLogic(IUserRepo userRepo, ISongRepo songRepo, IProfileRepo profileRepo)
        {
            _userRepo = userRepo;
            _songRepo = songRepo;
            _profileRepo = profileRepo;
        }

        public bool CreateSong(ClaimsPrincipal claimsPrincipal, Song song)
        {
            var user = _userRepo.GetUserByKeycloakIdentifier(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
            song.Profile = user.Profile;

            _songRepo.CreateSong(song);

            return _songRepo.SaveChanges();
        }

        public bool DeleteSong(ClaimsPrincipal claimsPrincipal, int songId)
        {
            var user = _userRepo.GetUserByKeycloakIdentifier(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (user.Profile.Hobbies.Any(h => h.Id == songId))
            {
                _songRepo.RemoveSong(songId);
                return _songRepo.SaveChanges();
            }

            return false;
        }

        public ICollection<Song> GetSongs(ClaimsPrincipal claimsPrincipal, int profileId)
        {
            if (profileId == 0)
            {
                var authenticatedUser = _userRepo.GetUserByKeycloakIdentifier(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
                return authenticatedUser.Profile.Songs;
            }

            var profile = _profileRepo.GetProfileById(profileId);

            if (profile == null) return new List<Song>();

            return profile.Songs;
        }
    }
}

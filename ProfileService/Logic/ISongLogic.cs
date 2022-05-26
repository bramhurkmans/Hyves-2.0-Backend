using ProfileService.Models;
using System.Security.Claims;

namespace ProfileService.Logic
{
    public interface ISongLogic
    {
        public ICollection<Song> GetSongs(ClaimsPrincipal claimsPrincipal, int profileId);

        public bool CreateSong(ClaimsPrincipal claimsPrincipal, Song song);

        public bool DeleteSong(ClaimsPrincipal claimsPrincipal, int songId);
    }
}

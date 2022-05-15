using System.Collections.Generic;
using ProfileService.Models;

namespace ProfileService.Data
{
    public interface ISongRepo
    {
        public bool SaveChanges();

        IEnumerable<Song> GetAllSongs();

        IEnumerable<Song> getSongsByProfileId(int profileId);

        Song GetSongById(int id);

        void CreateSong(Song song);

        void RemoveSong(int songId);
    }
}
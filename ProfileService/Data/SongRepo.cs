using System;
using System.Collections.Generic;
using System.Linq;
using ProfileService.Models;

namespace ProfileService.Data
{
    public class SongRepo : ISongRepo
    {
        private readonly AppDbContext _context;

        public SongRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateSong(Song song)
        {
            if(song == null) {
                throw new ArgumentNullException(nameof(song));
            }

            _context.Add(song);
        }

        public IEnumerable<Song> GetAllSongs()
        {
            return _context.Songs.ToList();
        }

        public Song GetSongById(int id)
        {
            return _context.Songs.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Song> getSongsByProfileId(int profileId)
        {
            return _context.Songs.Where(h => h.Profile.Id == profileId);
        }

        public void RemoveSong(int songId)
        {
            var song = _context.Songs.FirstOrDefault(p => p.Id == songId);

            _context.Songs.Remove(song);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
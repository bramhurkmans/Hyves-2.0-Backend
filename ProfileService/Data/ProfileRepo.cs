using System;
using System.Collections.Generic;
using System.Linq;
using ProfileService.Models;

namespace ProfileService.Data
{
    public class ProfileRepo : IProfileRepo
    {
        private readonly AppDbContext _context;

        public ProfileRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateProfile(Profile profile)
        {
            if(profile == null) {
                throw new ArgumentNullException(nameof(profile));
            }

            _context.Add(profile);
        }

        public IEnumerable<Profile> GetAllProfiles()
        {
            return _context.Profiles.ToList();
        }

        public Profile GetProfileById(int id)
        {
            return _context.Profiles.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
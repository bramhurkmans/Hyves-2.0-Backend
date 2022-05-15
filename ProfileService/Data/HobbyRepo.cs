using System;
using System.Collections.Generic;
using System.Linq;
using ProfileService.Models;

namespace ProfileService.Data
{
    public class HobbyRepo : IHobbyRepo
    {
        private readonly AppDbContext _context;

        public HobbyRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateHobby(Hobby hobby)
        {
            if(hobby == null) {
                throw new ArgumentNullException(nameof(hobby));
            }

            _context.Add(hobby);
        }

        public void RemoveHobby(int hobbyId)
        {
            var hobby = _context.Hobbies.FirstOrDefault(p => p.Id == hobbyId);

            _context.Hobbies.Remove(hobby);
        }

        public IEnumerable<Hobby> GetAllHobbies()
        {
            return _context.Hobbies.ToList();
        }

        public IEnumerable<Hobby> getHobbiesByProfileId(int profileId)
        {
            return _context.Hobbies.Where(h => h.Profile.Id == profileId);
        }

        public Hobby GetHobbyById(int id)
        {
            return _context.Hobbies.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
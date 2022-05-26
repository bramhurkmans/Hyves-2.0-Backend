using System;
using System.Collections.Generic;
using System.Linq;
using ProfileService.Models;

namespace ProfileService.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            if(user == null) {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public bool ExternalUserExists(int externalUserId)
        {
            return _context.Users.Any(p => p.ExternalId == externalUserId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public User GetUserByKeycloakIdentifier(string keyCloakIdentifier)
        {
            return _context.Users.FirstOrDefault(p => p.KeyCloakIdentifier == keyCloakIdentifier);
        }
    }
}
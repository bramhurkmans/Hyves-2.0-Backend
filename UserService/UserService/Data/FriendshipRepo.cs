using System;
using System.Collections.Generic;
using System.Linq;
using UserService.Models;

namespace UserService.Data
{
    public class FriendshipRepo : IFriendshipRepo
    {
        private readonly AppDbContext _context;

        public FriendshipRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateFriendship(Friendship friendship)
        {
            if(friendship == null) {
                throw new ArgumentNullException(nameof(friendship));
            }

            _context.Add(friendship);
        }

        public IEnumerable<Friendship> GetAllFriendships()
        {
            return _context.Friendships.ToList();
        }

        public Friendship GetFriendshipById(int id)
        {
            return _context.Friendships.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
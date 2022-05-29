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

        public void RemoveFriendship(Friendship friendship)
        {
            if (friendship == null)
            {
                throw new ArgumentNullException(nameof(friendship));
            }

            _context.Remove(friendship);
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

        public void UpdateFriendship(Friendship friendship)
        {
            _context.Friendships.Update(friendship);
        }

        public IEnumerable<Friendship> GetFriendshipByUser(User user)
        {
            return _context.Friendships.Where(f => f.RequestedTo.Id == user.Id || f.RequestedBy.Id == user.Id);
        }
    }
}
using System.Collections.Generic;
using UserService.Models;

namespace UserService.Data
{
    public interface IFriendshipRepo
    {
        public bool SaveChanges();

        IEnumerable<Friendship> GetAllFriendships();

        IEnumerable<Friendship> GetFriendshipByUser(User user);

        Friendship GetFriendshipById(int id);

        void CreateFriendship(Friendship friendship);

        void RemoveFriendship(Friendship friendship);

        void UpdateFriendship(Friendship friendship);
    }
}
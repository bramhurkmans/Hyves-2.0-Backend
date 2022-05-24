using System.Collections.Generic;
using UserService.Models;

namespace UserService.Data
{
    public interface IFriendshipRepo
    {
        public bool SaveChanges();

        IEnumerable<Friendship> GetAllFriendships();

        Friendship GetFriendshipById(int id);

        void CreateFriendship(Friendship friendship);
    }
}
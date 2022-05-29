using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using UserService.Data;
using UserService.Models;

namespace UserService.Logic
{
    public class FriendLogic : IFriendLogic
    {
        private readonly IFriendshipRepo _friendRepo;
        private readonly IUserRepo _userRepo;

        public FriendLogic(IFriendshipRepo friendRepo, IUserRepo userRepo)
        {
            _friendRepo = friendRepo;
            _userRepo = userRepo;
        }

        public bool Accept(ClaimsPrincipal claimsPrincipal, int friendshipId)
        {
            var user = _userRepo.GetUserByKeycloakIdentifier(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
            var friendship = _friendRepo.GetFriendshipById(friendshipId);

            if (user == null)
                return false;

            if (friendship == null)
                return false;

            if(friendship.RequestedTo.Id == user.Id)
            {
                friendship.FriendRequestFlag = Models.FriendRequestFlag.Approved;
                _friendRepo.UpdateFriendship(friendship);
                _friendRepo.SaveChanges();
                return true;
            }

            return false;

        }

        public bool Decline(ClaimsPrincipal claimsPrincipal, int friendshipId)
        {
            var user = _userRepo.GetUserByKeycloakIdentifier(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
            var friendship = _friendRepo.GetFriendshipById(friendshipId);

            if (user == null)
                return false;

            if (friendship == null)
                return false;

            if (friendship.RequestedTo.Id == user.Id)
            {
                _friendRepo.RemoveFriendship(friendship);
                _friendRepo.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(ClaimsPrincipal claimsPrincipal, int friendshipId)
        {
            var user = _userRepo.GetUserByKeycloakIdentifier(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
            var friendship = _friendRepo.GetFriendshipById(friendshipId);

            if (user == null)
                return false;

            if (friendship == null)
                return false;

            if (friendship.RequestedTo.Id == user.Id || friendship.RequestedBy.Id == user.Id)
            {
                _friendRepo.RemoveFriendship(friendship);
                _friendRepo.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<Friendship> List(int userId)
        {
            var user = _userRepo.GetUserById(userId);

            if (user == null)
                return new List<Friendship>();

            return _friendRepo.GetFriendshipByUser(user);
        }

        public bool Send(ClaimsPrincipal claimsPrincipal, int userId)
        {
            var requestedBy = _userRepo.GetUserByKeycloakIdentifier(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
            var requestedTo = _userRepo.GetUserById(userId);

            if (requestedBy == null || requestedTo == null)
                return false;

            _friendRepo.CreateFriendship(new Models.Friendship()
            {
                RequestedBy = requestedBy,
                RequestedTo = requestedTo,
                FriendRequestFlag = Models.FriendRequestFlag.Waiting
            });
            _friendRepo.SaveChanges();

            return true;
        }
    }
}

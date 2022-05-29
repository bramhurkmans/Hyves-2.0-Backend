using System.Collections.Generic;
using System.Security.Claims;
using UserService.Models;

namespace UserService.Logic
{
    public interface IFriendLogic
    {
        bool Accept(ClaimsPrincipal claimsPrincipal, int friendshipId);

        bool Decline(ClaimsPrincipal claimsPrincipal, int friendshipId);

        bool Send(ClaimsPrincipal claimsPrincipal, int userId);

        bool Delete(ClaimsPrincipal claimsPrincipal, int friendshipId);

        IEnumerable<Friendship> List(int userId);
    }
}

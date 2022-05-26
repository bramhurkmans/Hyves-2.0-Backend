using ProfileService.Models;
using System.Security.Claims;

namespace ProfileService.Logic
{
    public interface IThemeLogic
    {
        public bool SetTheme(ClaimsPrincipal claimsPrincipal, int profileId, Theme theme);
    }
}

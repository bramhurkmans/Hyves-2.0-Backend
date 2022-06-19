using ProfileService.Models;
using System.Security.Claims;

namespace ProfileService.Logic
{
    public interface IThemeLogic
    {
        public Theme GetByProfileId(int profileId);
        public bool UpdateTheme(ClaimsPrincipal claimsPrincipal, Theme theme);
    }
}

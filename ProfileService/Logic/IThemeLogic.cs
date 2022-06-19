using ProfileService.Models;
using System.Security.Claims;

namespace ProfileService.Logic
{
    public interface IThemeLogic
    {
        public bool UpdateTheme(ClaimsPrincipal claimsPrincipal, Theme theme);
    }
}

using ProfileService.Data;
using ProfileService.Models;
using System.Security.Claims;

namespace ProfileService.Logic
{
    public class ThemeLogic : IThemeLogic
    {

        private readonly IThemeRepo _themeRepo;

        public ThemeLogic(IThemeRepo themeRepo)
        {
            _themeRepo = themeRepo;
        }
        public bool SetTheme(ClaimsPrincipal claimsPrincipal, int profileId, Theme theme)
        {
            throw new NotImplementedException();
        }
    }
}

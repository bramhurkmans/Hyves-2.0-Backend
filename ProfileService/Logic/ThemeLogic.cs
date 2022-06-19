using ProfileService.Data;
using ProfileService.Models;
using System.Security.Claims;

namespace ProfileService.Logic
{
    public class ThemeLogic : IThemeLogic
    {

        private readonly IThemeRepo _themeRepo;
        private readonly IUserRepo _userRepo;

        public ThemeLogic(IThemeRepo themeRepo)
        {
            _themeRepo = themeRepo;
        }
        public bool UpdateTheme(ClaimsPrincipal claimsPrincipal, Theme theme)
        {
            var user = _userRepo.GetUserByKeycloakIdentifier(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (user.Profile.Theme.Id != theme.Id) return false;

            _themeRepo.CreateTheme(theme);

            return _themeRepo.SaveChanges();
        }
    }
}

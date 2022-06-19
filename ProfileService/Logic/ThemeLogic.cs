using ProfileService.Data;
using ProfileService.Models;
using System.Security.Claims;

namespace ProfileService.Logic
{
    public class ThemeLogic : IThemeLogic
    {

        private readonly IThemeRepo _themeRepo;
        private readonly IUserRepo _userRepo;

        public ThemeLogic(IThemeRepo themeRepo, IUserRepo userRepo)
        {
            _themeRepo = themeRepo;
            _userRepo = userRepo;
        }

        public Theme GetByProfileId(int profileId)
        {
            return _themeRepo.GetThemeByProfileId(profileId);
        }

        public bool UpdateTheme(ClaimsPrincipal claimsPrincipal, Theme theme)
        {
            var identifier = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _userRepo.GetUserByKeycloakIdentifier(identifier);

            if (user.Profile.Theme.Id != theme.Id) return false;

            _themeRepo.UpdateTheme(theme);

            return _themeRepo.SaveChanges();
        }
    }
}

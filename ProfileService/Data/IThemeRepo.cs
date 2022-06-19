using System.Collections.Generic;
using ProfileService.Models;

namespace ProfileService.Data
{
    public interface IThemeRepo
    {
        public bool SaveChanges();

        IEnumerable<Theme> GetAllThemes();

        Theme GetThemeByProfileId(int profileId);

        Theme GetThemeById(int id);

        void CreateTheme(Theme theme);

        void UpdateTheme(Theme theme);

        void RemoveTheme(int themeId);
    }
}
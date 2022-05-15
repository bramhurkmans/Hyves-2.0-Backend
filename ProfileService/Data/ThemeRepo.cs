using System;
using System.Collections.Generic;
using System.Linq;
using ProfileService.Models;

namespace ProfileService.Data
{
    public class ThemeRepo : IThemeRepo
    {
        private readonly AppDbContext _context;

        public ThemeRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateTheme(Theme theme)
        {
            if(theme == null) {
                throw new ArgumentNullException(nameof(theme));
            }

            _context.Add(theme);
        }

        public IEnumerable<Theme> GetAllThemes()
        {
            return _context.Themes.ToList();
        }

        public Theme GetThemeById(int id)
        {
            return _context.Themes.FirstOrDefault(p => p.Id == id);
        }

        public Theme GetThemeByProfileId(int profileId)
        {
            throw new NotImplementedException();
        }

        public void RemoveTheme(int themeId)
        {
            var theme = _context.Themes.FirstOrDefault(p => p.Id == themeId);

            _context.Themes.Remove(theme);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
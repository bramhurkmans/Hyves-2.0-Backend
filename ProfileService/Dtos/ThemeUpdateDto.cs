using System.ComponentModel.DataAnnotations;
using ProfileService.Models;

namespace ProfileService.Dtos
{
    public class ThemeUpdateDto
    {
        public int Id { get; set; }

        public string PrimaryColor { get; set; }

        public string SecondaryColor { get; set; }

        public string TextColor { get; set; }
    }
}
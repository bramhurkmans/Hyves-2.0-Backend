using System.ComponentModel.DataAnnotations;
using ProfileService.Models;

namespace ProfileService.Dtos
{
    public class ThemeReadDto
    {
        public int Id { get; set; }

        public string PrimaryColor { get; set; }

        public string SecondaryColor { get; set; }

        public string TextColor { get; set; }

        public virtual Profile Profile { get; set; }

        public int ProfileId { get; set; }
    }
}
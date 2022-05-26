using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProfileService.Models
{
    public class Theme
    {
        [Key]
        [Required]
        public int Id { get; set; } 

        public string PrimaryColor { get; set; }

        public string SecondaryColor { get; set; }

        public string TextColor { get; set; }

        public virtual Profile Profile { get; set; }

        public int ProfileId { get; set; }
    }
}
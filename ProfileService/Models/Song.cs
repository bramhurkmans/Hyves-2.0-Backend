using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProfileService.Models
{
    public class Song
    {
        [Key]
        [Required]
        public int Id { get; set; } 

        public string Artist { get; set; }

        public string Title { get; set; }

        public virtual Profile Profile { get; set; }

        public int ProfileId { get; set; }
    }
}
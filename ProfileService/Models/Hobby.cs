using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProfileService.Models
{
    public class Hobby
    {
        [Key]
        [Required]
        public int Id { get; set; } 

        public string Name { get; set; }

        public virtual Profile Profile { get; set; }

        public int ProfileId { get; set; }

    }
}
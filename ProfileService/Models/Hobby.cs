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

        public Profile Profile { get; set; }
    }
}
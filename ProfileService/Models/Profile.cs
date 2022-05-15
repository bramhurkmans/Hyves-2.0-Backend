using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProfileService.Models
{
    public class Profile
    {
        [Key]
        [Required]
        public int Id { get; set; } 

        [Required]
        public User User { get; set; } 

        public Theme? Theme { get; set; } 

        public ICollection<Song> Songs { get; set; }

        public ICollection<Hobby> Hobbies { get; set; }
    }
}
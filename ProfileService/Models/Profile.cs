using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProfileService.Models
{
    public class Profile
    {
        [Key]
        [Required]
        public int Id { get; set; } 

        public virtual User User { get; set; }

        public int UserId { get; set; }

        public virtual Theme? Theme { get; set; } 

        public virtual ICollection<Song> Songs { get; set; }

        public virtual ICollection<Hobby> Hobbies { get; set; }
    }
}
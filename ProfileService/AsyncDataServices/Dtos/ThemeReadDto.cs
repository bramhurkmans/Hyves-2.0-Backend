using System.ComponentModel.DataAnnotations;
using ProfileService.Models;

namespace ProfileService.Dtos
{
    public class ThemeReadDto
    {
        public int Id { get; set; } 

        public User User { get; set; } 

        public Theme? Theme { get; set; } 

        public ICollection<Song> Songs { get; set; }

        public ICollection<Hobby> Hobbies { get; set; }
    }
}
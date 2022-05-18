using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; } 

        [Required]
        public string FirstName { get; set; }   

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public ICollection<User> Friends { get; set; }
    }
}
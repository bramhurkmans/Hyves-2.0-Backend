using System.ComponentModel.DataAnnotations;

namespace UserService.Dtos
{
    public class UserCreateDto
    {
        [Required]
        public string Name { get; set; }   

        public string FirstName { get; set; }   

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

    }
}
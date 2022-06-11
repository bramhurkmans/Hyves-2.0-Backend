using System.ComponentModel.DataAnnotations;

namespace KrabbelService.Dtos
{
    public class UserReadDto
    {
        public int Id { get; set; }

        public bool IsPrivate { get; set; }

        public string KeyCloakIdentifier { get; set; }

        public string FirstName { get; set; }   

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KrabbelService.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int ExternalId { get; set; }

        [Required]
        public bool IsPrivate { get; set; }

        [Required]
        public string KeyCloakIdentifier { get; set; }

        [Required]
        public string FirstName { get; set; }   

        [Required]
        public string LastName { get; set; }

        public virtual List<Krabbel> Krabbels { get; set; }
    }
}
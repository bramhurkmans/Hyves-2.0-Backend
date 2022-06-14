using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KrabbelService.Models
{
    public class Krabbel
    {
        [Key]
        [Required]
        public int Id { get; set; } 

        public virtual User Sender { get; set; }

        public virtual User Receiver { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}
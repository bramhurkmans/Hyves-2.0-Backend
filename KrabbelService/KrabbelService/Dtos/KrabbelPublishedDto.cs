using KrabbelService.Models;

namespace KrabbelService.Dtos
{
    public class KrabbelPublishedDto
    {
        public int Id { get; set; } 

        public User Sender { get; set; } 

        public User Receiver { get; set; } 

        public DateTime Date { get; set; } 

        public string Text { get; set; } 
    }
}
using System.ComponentModel.DataAnnotations;
using ProfileService.Models;

namespace ProfileService.Dtos
{
    public class HobbyReadDto
    {
        public int Id { get; set; } 

        public string Name { get; set; } 
    }
}
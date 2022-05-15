using System.ComponentModel.DataAnnotations;
using ProfileService.Models;

namespace ProfileService.Dtos
{
    public class SongReadDto
    {
        public int Id { get; set; } 

        public string Artist { get; set; }

        public string Title { get; set; }

    }
}
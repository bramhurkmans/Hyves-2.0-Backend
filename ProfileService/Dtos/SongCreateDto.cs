using System.ComponentModel.DataAnnotations;

namespace ProfileService.Dtos
{
    public class SongCreateDto
    {
        public string Artist { get; set; }

        public string Title { get; set; }
    }
}
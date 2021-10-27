using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Common.Dtos.DirectorDtos
{
    public class DirectorCreateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}

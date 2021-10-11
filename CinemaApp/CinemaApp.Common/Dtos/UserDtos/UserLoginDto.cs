
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Common.Dtos.UserDtos
{
    public class UserLoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

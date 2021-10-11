using System.ComponentModel.DataAnnotations;


namespace CinemaApp.Common.Dtos.UserDtos
{
    public class UserRegistrationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

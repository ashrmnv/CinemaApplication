using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Common.Dtos.MovieDtos
{
    public class MovieUpdateDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Description is too short/long")]
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string Genre { get; set; }
        [Required]
        public DateTime PremiereDate { get; set; }

        [Range(0, 10)]
        public double Rating { get; set; }
        [Required]
        [Range(1, 999)]
        public int DirectorId { get; set; }
    }
}

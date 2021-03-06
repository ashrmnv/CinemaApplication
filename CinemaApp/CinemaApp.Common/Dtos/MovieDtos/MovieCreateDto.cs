using CinemaApp.Common.Dtos.DirectorDtos;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Common.Dtos.MovieDtos
{
    public class MovieCreateDto
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
        [Required]
        public int DirectorId { get; set; }
    }
}

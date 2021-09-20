using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Common.Dtos.MovieDtos
{
    public class MoviePartialUpdateDto
    {
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Title is too short/long")]
        public string Title { get; set; }
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Description is too short/long")]
        public string Description { get; set; }
        [MaxLength(100)]
        public string Genre { get; set; }
        [Range(0, 10)]
        public double? Rating { get; set; }
        [Range(1, 9999)]
        public int? DirectorId { get; set; }
    }
}

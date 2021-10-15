using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Common.Dtos.MovieDtos
{
    public class MovieRatingDto
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        [Range(0,10)]
        public int Rating { get; set; }
    }
}

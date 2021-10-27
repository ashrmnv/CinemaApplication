using CinemaApp.Common.Dtos.ActorDtos;
using CinemaApp.Common.Dtos.DirectorDtos;
using CinemaApp.Common.Dtos.PosterDtos;
using System;
using System.Collections.Generic;

namespace CinemaApp.Common.Dtos.MovieDtos
{
    public class MovieDetailsReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime PremiereDate { get; set; }
        public double RatingsSum { get; set; }
        public int RatingsNumber { get; set; }
        public DirectorReadDto DirectorReadDto { get; set; }
        public PosterReadDto PosterReadDto { get; set; }
        public ICollection<ActorReadDto> Actors { get; set; }

    }
}

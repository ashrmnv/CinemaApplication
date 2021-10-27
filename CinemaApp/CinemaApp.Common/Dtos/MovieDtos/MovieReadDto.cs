using CinemaApp.Common.Dtos.DirectorDtos;
using CinemaApp.Common.Dtos.PosterDtos;
using System;

namespace CinemaApp.Common.Dtos.MovieDtos
{
    public class MovieReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime PremiereDate { get; set; }
        public DirectorReadDto DirectorReadDto { get; set; }
        public PosterReadDto PosterReadDto { get; set; }

    }
}


using CinemaApp.Common.Dtos.DirectorDtos;
using System;

namespace CinemaApp.Common.Dtos.MovieDtos
{
    public class MovieReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime PremiereDate { get; set; }
        public double Rating { get; set; }
        public DirectorReadDto DirectorReadDto { get; set; }

    }
}

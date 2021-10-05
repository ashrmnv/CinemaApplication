using CinemaApp.Common.Dtos.ActorDtos;
using CinemaApp.Common.Dtos.CommentDtos;
using CinemaApp.Common.Dtos.DirectorDtos;
using CinemaApp.Domain;
using System;
using System.Collections.Generic;

namespace CinemaApp.Common.Dtos.MovieDtos
{
    public class SingleMovieReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime PremiereDate { get; set; }

        public double Rating { get; set; }
        public DirectorReadDto DirectorReadDto { get; set; }
        public ICollection<ActorReadDto> Actors { get; set; }
        public ICollection<CommentReadDto> Comments { get; set; }

    }
}

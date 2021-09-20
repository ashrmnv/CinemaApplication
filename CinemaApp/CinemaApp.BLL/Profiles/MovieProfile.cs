using AutoMapper;
using CinemaApp.Common.Dtos.MovieDtos;
using CinemaApp.Domain;

namespace CinemaApp.BLL.Profiles
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            CreateMap<Movie, ManyMoviesReadDto>();
            CreateMap<Movie, SingleMovieReadDto>();
            CreateMap<MovieCreateDto, Movie>();
            CreateMap<MovieUpdateDto, Movie>();
            CreateMap<MoviePartialUpdateDto, Movie>();
        }
    }
}

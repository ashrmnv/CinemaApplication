using AutoMapper;
using CinemaApp.Common.Dtos.MovieDtos;
using CinemaApp.Common.Models;
using CinemaApp.Domain;

namespace CinemaApp.BLL.Profiles
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            CreateMap<Movie, MovieReadDto>();
            CreateMap<PaginatedResult<Movie>, PaginatedResult<MovieReadDto>>();
            CreateMap<Movie, MovieDetailsReadDto>();
            CreateMap<MovieCreateDto, Movie>();
            CreateMap<MovieUpdateDto, Movie>();
            CreateMap<MoviePartialUpdateDto, Movie>();
            CreateMap<MovieRatingDto, RatedMovies>();
        }
    }
}

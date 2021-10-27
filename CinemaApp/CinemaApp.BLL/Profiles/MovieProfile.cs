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
            CreateMap<Movie, MovieReadDto>()
                .ForMember(x => x.DirectorReadDto, y => y.MapFrom(z => z.Director))
                .ForMember(x => x.PosterReadDto, y=> y.MapFrom(z => z.Poster));
            CreateMap<PaginatedResult<Movie>, PaginatedResult<MovieReadDto>>();
            CreateMap<Movie, MovieDetailsReadDto>()
                .ForMember(x => x.Actors, y => y.MapFrom(z => z.Actors))
                .ForMember(x => x.DirectorReadDto, y => y.MapFrom(z => z.Director))
                .ForMember(x => x.PosterReadDto, y => y.MapFrom(z => z.Poster));
            CreateMap<MovieCreateDto, Movie>();
            CreateMap<MovieUpdateDto, Movie>();
            CreateMap<MoviePartialUpdateDto, Movie>();
            CreateMap<MovieRatingDto, RatedMovies>();
        }
    }
}

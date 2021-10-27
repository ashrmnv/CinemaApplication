using AutoMapper;
using CinemaApp.Common.Dtos.PosterDtos;
using CinemaApp.Domain;

namespace CinemaApp.BLL.Profiles
{
    class PosterProfile : Profile
    {
        public PosterProfile()
        {
            CreateMap<Poster, PosterReadDto>();
        }
    }
}

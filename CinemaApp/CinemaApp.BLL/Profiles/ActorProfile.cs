using AutoMapper;
using CinemaApp.Common.Dtos.ActorDtos;
using CinemaApp.Domain;

namespace CinemaApp.BLL.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorReadDto>();
        }
    }
}

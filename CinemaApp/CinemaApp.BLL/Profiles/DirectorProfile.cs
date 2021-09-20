using AutoMapper;
using CinemaApp.Domain;
using CinemaApp.Common.Dtos.DirectorDtos;

namespace CinemaApp.BLL.Profiles
{
    public class DirectorProfile : Profile
    {
        public DirectorProfile()
        {
            CreateMap<Director, DirectorReadDto>();
        }
    }
}

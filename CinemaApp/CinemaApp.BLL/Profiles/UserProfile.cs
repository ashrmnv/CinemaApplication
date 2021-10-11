using AutoMapper;
using CinemaApp.Common.Dtos.UserDtos;
using CinemaApp.Domain;

namespace CinemaApp.BLL.Profiles
{
    class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegistrationDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}

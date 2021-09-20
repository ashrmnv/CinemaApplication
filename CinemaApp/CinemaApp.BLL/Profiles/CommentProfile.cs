using AutoMapper;
using CinemaApp.Common.Dtos.CommentDtos;
using CinemaApp.Domain;

namespace CinemaApp.BLL.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentReadDto>();
        }
    }
}

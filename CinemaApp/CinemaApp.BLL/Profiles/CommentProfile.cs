using AutoMapper;
using CinemaApp.Common.Dtos.CommentDtos;
using CinemaApp.Common.Models;
using CinemaApp.Domain;

namespace CinemaApp.BLL.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentReadDto>()
                .ForMember(x => x.UserDto, y => y.MapFrom(z => z.User));
            CreateMap<CommentCreateDto, Comment>();
            CreateMap<CommentUpdateDto, Comment>();
            CreateMap<PaginatedResult<Comment>, PaginatedResult<CommentReadDto>>();

        }
    }
}

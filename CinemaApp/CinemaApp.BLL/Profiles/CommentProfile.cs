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
            CreateMap<Comment, CommentReadDto>();
            CreateMap<CommentCreateDto, Comment>();
            CreateMap<CommentUpdateDto, CommentReadDto>();
            CreateMap<PaginatedResult<Comment>, PaginatedResult<CommentReadDto>>();

        }
    }
}

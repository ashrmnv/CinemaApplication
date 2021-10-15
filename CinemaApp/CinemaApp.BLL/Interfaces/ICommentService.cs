using CinemaApp.Common.Dtos.CommentDtos;
using CinemaApp.Common.Models;

namespace CinemaApp.BLL.Interfaces
{
    public interface ICommentService
    {
        PaginatedResult<CommentReadDto> GetPagedResult(PagedRequest pagedRequest);
        CommentReadDto CreateComment(CommentCreateDto commentDto);
        CommentReadDto UpdateComment(int id, CommentUpdateDto commentDto);
        bool DeleteComment(int id);
    }
}

using CinemaApp.BLL.Exceptions;
using CinemaApp.BLL.Interfaces;
using CinemaApp.Common.Dtos.CommentDtos;
using CinemaApp.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.API.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("paginated-result")]
        public IActionResult GetPaginatedMovies(PagedRequest pagedRequest)
        {
            var commentReadDtos = _commentService.GetPagedResult(pagedRequest);
            return Ok(commentReadDtos);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddComment([FromBody] CommentCreateDto commentDto)
        {
            var commentReadDto = _commentService.CreateComment(commentDto);
            return Ok(commentReadDto);
        }

        [HttpPut("{commentId}")]
        [CinemaApiExceptionFilter]
        [Authorize]
        public IActionResult UpdateComment(int id, [FromBody] CommentUpdateDto commentDto)
        {
            var commentReadDto = _commentService.UpdateComment(id, commentDto);
            return Ok(commentReadDto);
        }

        [HttpDelete("{commentId}")]
        [Authorize]
        public IActionResult Delete(int commentId)
        {
            var isDeleted = _commentService.DeleteComment(commentId);

            return isDeleted ? NoContent() : NotFound();
        }
    }
}

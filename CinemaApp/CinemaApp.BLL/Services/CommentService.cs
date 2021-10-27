using AutoMapper;
using CinemaApp.BLL.Exceptions;
using CinemaApp.BLL.Interfaces;
using CinemaApp.Common.Dtos.CommentDtos;
using CinemaApp.Common.Dtos.UserDtos;
using CinemaApp.Common.Models;
using CinemaApp.DAL.Interfaces;
using CinemaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _repository;
        private readonly IMapper _mapper;

        public CommentService(IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CommentReadDto CreateComment(CommentCreateDto commentCreateDto)
        {
            var commentModel = _mapper.Map<Comment>(commentCreateDto);
            _repository.Add(commentModel);
            var commentDto = _mapper.Map<CommentReadDto>(commentModel);
            return commentDto;
        }

        public bool DeleteComment(int id)
        {
            var comment = _repository.GetById(id);
            if (comment != null)
            {
                _repository.Delete(comment);
                return true;
            }
            else
            {
                return false;
            }
        }

        public PaginatedResult<CommentReadDto> GetPagedResult(PagedRequest pagedRequest)
        {
            var commentsList = _repository.GetPagedDataWithInclude(pagedRequest, x => x.User);
            var commentListDtos = _mapper.Map<PaginatedResult<CommentReadDto>>(commentsList);
            return commentListDtos;
        }

        public CommentReadDto UpdateComment(int id, CommentUpdateDto commentDto)
        {
            var commentModel = _repository.GetById(id);
            if (commentModel != null)
            {
                _mapper.Map(commentDto, commentModel);
                _repository.Update(commentModel);
            }
            else
            {
                throw new CommentNotFoundException("Comment not found");
            }

            var commentReadDto = _mapper.Map<CommentReadDto>(commentModel);
            return commentReadDto;
        }
    }
}

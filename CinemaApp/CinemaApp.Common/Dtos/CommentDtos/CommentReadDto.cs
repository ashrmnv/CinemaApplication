using CinemaApp.Common.Dtos.UserDtos;
using System;

namespace CinemaApp.Common.Dtos.CommentDtos
{
    public class CommentReadDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime CreatingDate { get; set; }
        public UserDto UserDto { get; set; }

    }
}

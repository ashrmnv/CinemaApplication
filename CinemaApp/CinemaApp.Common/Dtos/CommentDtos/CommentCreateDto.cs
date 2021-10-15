using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Common.Dtos.CommentDtos
{
    public class CommentCreateDto
    {
        [Required]
        public string Body { get; set; }
        [Required]
        public DateTime CreatingDate { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}

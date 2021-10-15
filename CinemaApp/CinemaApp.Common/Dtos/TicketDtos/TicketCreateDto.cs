using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Common.Dtos.TicketDtos
{
    public class TicketCreateDto
    {
        [Required]
        public int Place { get; set; }
        [Required]
        public int Row { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int SessionId { get; set; }
    }
}

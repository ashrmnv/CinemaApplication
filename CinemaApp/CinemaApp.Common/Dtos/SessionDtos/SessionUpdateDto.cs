using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Common.Dtos.SessionDtos
{
    public class SessionUpdateDto
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }
        [Range(1, 999)]
        public int? MovieId { get; set; }
    }
}

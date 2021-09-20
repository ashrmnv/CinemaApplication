using CinemaApp.Common.Dtos.TicketDtos;
using System;
using System.Collections.Generic;

namespace CinemaApp.Common.Dtos.SessionDtos
{
    public class SessionReadDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<TicketReadDto> Tickets { get; set; }
    }
}

using CinemaApp.Common.Dtos.TicketDtos;
using System.Collections.Generic;


namespace CinemaApp.BLL.Interfaces
{
    public interface ITicketService
    {
        TicketReadDto CreateTicket(TicketCreateDto ticketDto); //BuyTicket
        bool DeleteTicket(int id); //Cancel the ticket
        IList<TicketReadDto> GetTickets(int sessionId);
    }
}

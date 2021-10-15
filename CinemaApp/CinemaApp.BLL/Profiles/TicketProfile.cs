using AutoMapper;
using CinemaApp.Common.Dtos.TicketDtos;
using CinemaApp.Domain;


namespace CinemaApp.BLL.Profiles
{
    public class TicketProfile:Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketReadDto>();
            CreateMap<TicketCreateDto, Ticket>();
        }
    }
}

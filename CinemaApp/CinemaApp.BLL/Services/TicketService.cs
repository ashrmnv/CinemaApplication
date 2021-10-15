using AutoMapper;
using CinemaApp.BLL.Exceptions;
using CinemaApp.BLL.Interfaces;
using CinemaApp.Common.Dtos.TicketDtos;
using CinemaApp.DAL.Interfaces;
using CinemaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BLL.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _repository;
        private readonly IMapper _mapper;

        public TicketService(IRepository<Ticket> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public TicketReadDto CreateTicket(TicketCreateDto ticketCreateDto)
        {
            var ticketModel = _mapper.Map<Ticket>(ticketCreateDto);
            var ticketCheck = _repository.Find(t =>
                t.Place == ticketModel.Place &&
                t.Row == ticketModel.Row &&
                t.SessionId == ticketModel.SessionId  
            );
            if (ticketCheck == null)
            {
                _repository.Add(ticketModel);
            }
            else
            {
                throw new TicketAlreadyPurchasedException("This ticket has already been purchased");
            }
            var ticketDto = _mapper.Map<TicketReadDto>(ticketModel);
            return ticketDto;
        }

        public bool DeleteTicket(int id)
        {
            var ticket = _repository.GetById(id);
            if (ticket != null)
            {
                _repository.Delete(ticket);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IList<TicketReadDto> GetTickets(int sessionId)
        {
            var tickets = _repository.FindAll(t => t.SessionId == sessionId).ToList();
            var ticketReadDtos = _mapper.Map<List<TicketReadDto>>(tickets);
            return ticketReadDtos;
        }
    }
}

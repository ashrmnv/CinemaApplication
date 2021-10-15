using CinemaApp.BLL.Exceptions;
using CinemaApp.BLL.Interfaces;
using CinemaApp.Common.Dtos.TicketDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CinemaApp.API.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]int sessionId)
        {
            var ticketReadDtos = _ticketService.GetTickets(sessionId);

            return Ok(ticketReadDtos);

        }

        [HttpPost]
        [CinemaApiExceptionFilter]
        [Authorize]
        public IActionResult BuyTicket([FromBody] TicketCreateDto ticketDto)
        {
            var ticketReadDto = _ticketService.CreateTicket(ticketDto);
            if (ticketReadDto != null)
            {
                return Ok(ticketReadDto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{ticketId}")]
        [Authorize]
        public IActionResult Delete(int ticketId)
        {
            var isDeleted = _ticketService.DeleteTicket(ticketId);

            return isDeleted ? NoContent() : NotFound();
        }
    }
}

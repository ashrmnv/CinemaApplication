using CinemaApp.BLL.Exceptions;
using CinemaApp.BLL.Interfaces;
using CinemaApp.Common.Dtos.SessionDtos;
using CinemaApp.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.API.Controllers
{
    [Route("sessions")]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        public SessionsController(ISessionService service)
        {
            _sessionService = service; 
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery]SessionFilterOptions filterOptions)
        {
            var sessionReadDtos = _sessionService.GetSessions(filterOptions);

            if (sessionReadDtos.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(sessionReadDtos);
            }
        }

        [HttpGet("{sessionId}", Name = "GetSessionById")]
        public IActionResult GetSessionById(int sessionId)
        {
            var sessionReadDto = _sessionService.GetSessionById(sessionId);
            if (sessionReadDto != null)
            {
                return Ok(sessionReadDto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateSession([FromBody] SessionCreateDto sessionDto)
        {
            var sessionReadDto = _sessionService.AddSession(sessionDto);
            return CreatedAtRoute(nameof(GetSessionById), new { Id = sessionReadDto.Id }, sessionReadDto);
        }

        [HttpPut("{id}")]
        [CinemaApiExceptionFilter]
        public IActionResult UpdateSession(int id, [FromBody] SessionUpdateDto sessionDto)
        {
            var sessionReadDto = _sessionService.UpdateSession(id, sessionDto);
            return Ok(sessionReadDto);
        }

        [HttpPatch("{id}")]
        [CinemaApiExceptionFilter]
        public IActionResult PartialUpdate(int id, [FromBody] SessionPartialUpdateDto sessionDto)
        {
            var sessionReadDto = _sessionService.UpdateSessionDetails(id, sessionDto);
            return Ok(sessionReadDto);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _sessionService.RemoveSession(id);

            return isDeleted ? NoContent() : NotFound();
        }
    }
}

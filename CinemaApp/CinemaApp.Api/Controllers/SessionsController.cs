using CinemaApp.BLL.Exceptions;
using CinemaApp.BLL.Interfaces;
using CinemaApp.Common.Dtos.SessionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.API.Controllers
{
    [Route("movies{movieId}/sessions")]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        public SessionsController(ISessionService service)
        {
            _sessionService = service; 
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var sessionReadDtos = _sessionService.GetSessions();

            return Ok(sessionReadDtos);
        }

        [HttpGet("{sessionId}", Name = "GetById")]
        public IActionResult GetById(int sessionId)
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
            return CreatedAtRoute(nameof(GetById), new { Id = sessionReadDto.Id }, sessionReadDto);
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

using CinemaApp.Common.Dtos.SessionDtos;
using System.Collections.Generic;

namespace CinemaApp.BLL.Interfaces
{
    public interface ISessionService
    {
        IList<SessionReadDto> GetSessions();
        SessionReadDto GetSessionById(int id);
        SessionReadDto AddSession(SessionCreateDto dto);
        SessionReadDto UpdateSessionDetails(int id, SessionPartialUpdateDto dto);
        SessionReadDto UpdateSession(int id, SessionUpdateDto dto);
        bool RemoveSession(int id);
    }
}

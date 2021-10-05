using AutoMapper;
using CinemaApp.BLL.Exceptions;
using CinemaApp.BLL.Interfaces;
using CinemaApp.Common.Dtos.SessionDtos;
using CinemaApp.Common.Models;
using CinemaApp.DAL.Interfaces;
using CinemaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BLL.Services
{
    public class SessionService : ISessionService
    {
        private readonly IRepository<Session> _repo;
        private readonly IRepository<Movie> _movieRepo;
        private readonly IMapper _mapper;
        public SessionService(IRepository<Session> repository, IRepository<Movie> movieRepo, IMapper mapper)
        {
            _repo = repository;
            _movieRepo = movieRepo;
            _mapper = mapper;
        }

        public SessionReadDto AddSession(SessionCreateDto dto)
        {
            var sessionModel = _mapper.Map<Session>(dto);

            _repo.Add(sessionModel);

            var sessionReadDto = _mapper.Map<SessionReadDto>(sessionModel);
            return sessionReadDto;
        }

        public SessionReadDto GetSessionById(int id)
        {
            var sessionModel = _repo.GetById(id);
            var sessionReadDto = _mapper.Map<SessionReadDto>(sessionModel);
            return sessionReadDto;
        }

        public IList<SessionReadDto> GetSessions(SessionFilterOptions filterOptions)
        {
            IQueryable<Session> sessions;
            if (filterOptions.MovieId.HasValue)
            {
                sessions = _repo.FindAll(s => s.MovieId == filterOptions.MovieId.Value);
            }
            else
            {
                sessions = _repo.GetAll();
            }

            if (filterOptions.DateTime.HasValue)
            {
                sessions = sessions.Where(s => s.DateTime.Date == filterOptions.DateTime.Value.Date);
            }
            var sessionReadDtos = _mapper.Map<List<SessionReadDto>>(sessions.ToList());
            return sessionReadDtos;

        }

        public bool RemoveSession(int id)
        {
            var session = _repo.GetById(id);
            if (session != null)
            {
                _repo.Delete(session);
                return true;
            }
            else
            {
                return false;
            }
        }

        public SessionReadDto UpdateSession(int id, SessionUpdateDto dto)
        {
            var sessionModel = _repo.GetById(id);
            if (sessionModel != null)
            {
                _mapper.Map(dto, sessionModel);
                _repo.Update(sessionModel);
            }
            else
            {
                throw new SessionNotFoundException("Session doesn't exists");
            }

            var sessionReadDto = _mapper.Map<SessionReadDto>(sessionModel);
            return sessionReadDto;
        }

        public SessionReadDto UpdateSessionDetails(int id, SessionPartialUpdateDto dto)
        {
            var sessionModel = _repo.GetById(id);
            if (sessionModel == null)
            {
                throw new SessionNotFoundException("Session doesn't exists");
            }

            if (dto.DateTime.HasValue)
                sessionModel.DateTime = dto.DateTime.Value;

            if (dto.MovieId.HasValue)
            {
                if (_movieRepo.GetById(dto.MovieId.Value) != null)
                {
                    sessionModel.MovieId = dto.MovieId.Value;
                }
                else
                {
                    throw new MovieNotFoundException("Movie doesn't exists");
                }
            }    

            _repo.Update(sessionModel);

            var sessionReadDto = _mapper.Map<SessionReadDto>(sessionModel);
            return sessionReadDto;
        }
    }
}

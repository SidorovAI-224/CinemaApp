using AutoMapper;
using CinemaApp.BL.DTOs.MovieDTOs.Session;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.BL.Services
{
    public class SessionService : ISessionService
    {
        private readonly IRepository<Session> _sessionRepository;
        private readonly IMapper _mapper;

        public SessionService(IRepository<Session> sessionRepository, IMapper mapper)
        {
            _sessionRepository = sessionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SessionDTO>> GetAllSessionsAsync()
        {
            var sessions = await _sessionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SessionDTO>>(sessions);
        }

        public async Task<SessionDTO> GetSessionByIdAsync(int id)
        {
            var session = await _sessionRepository.GetByIdAsync(id, include: q => q.Include(s => s.Movie));
            if (session == null)
            {
                throw new Exception("Session not found.");
            }
            return _mapper.Map<SessionDTO>(session);
        }
        public async Task<SessionDTO> AddSessionAsync(SessionCreateDTO sessionCreateDto)
        {
            var session = _mapper.Map<Session>(sessionCreateDto);
            await _sessionRepository.AddAsync(session);

            var createdSession = await _sessionRepository.GetByIdAsync(session.SessionId);
            if (createdSession == null)
            {
                throw new Exception("Save in DB error.");
            }

            return _mapper.Map<SessionDTO>(createdSession);
        }

        public async Task UpdateSessionAsync(int id, SessionUpdateDTO sessionUpdateDto)
        {
            var session = await _sessionRepository.GetByIdAsync(id);
            if (session == null)
            {
                throw new Exception("Session not found.");
            }

            _mapper.Map(sessionUpdateDto, session);
            await _sessionRepository.UpdateAsync(session);
        }

        public async Task DeleteSessionByIdAsync(int id)
        {
            await _sessionRepository.DeleteByIdAsync(id);
        }
    }
}
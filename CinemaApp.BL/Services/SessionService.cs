using AutoMapper;
using CinemaApp.BL.DTOs.MovieDTOs.Session;
using CinemaApp.BL.Interfaces;
using CinemaApp.DAL.Data;
using CinemaApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.BL.Services
{
    public class SessionService : ISessionService
    {
        private readonly IRepository<Session> _sessionRepository;
        private readonly CinemaDbContext _context;
        private readonly IMapper _mapper;

        public SessionService(IRepository<Session> sessionRepository, IMapper mapper, CinemaDbContext context)
        {
            _sessionRepository = sessionRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<SessionDTO>> GetAllSessionsAsync()
        {
            var sessions = await _sessionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SessionDTO>>(sessions);
        }
        /*

        public async Task<SessionDTO> GetSessionByIdAsync(int id)
        {
            var session = await _sessionRepository.GetByIdAsync(id, include: q => q.Include(s => s.Movie));
            if (session == null)
            {
                throw new Exception("Session not found.");
            }
            return _mapper.Map<SessionDTO>(session);

        }
        */
        public async Task<SessionDTO> GetSessionByIdAsync(int id)
        {
            var session = await _context.Sessions
                .Include(s => s.Movie)
                .FirstOrDefaultAsync(s => s.SessionID == id);

            return _mapper.Map<SessionDTO>(session);
        }
        public async Task<SessionDTO> AddSessionAsync(SessionCreateDTO sessionCreateDTO)
        {
            var session = _mapper.Map<Session>(sessionCreateDTO);
            await _sessionRepository.AddAsync(session);

            var createdSession = await _sessionRepository.GetByIdAsync(session.SessionID);
            if (createdSession == null)
            {
                throw new Exception("Save in DB error.");
            }

            return _mapper.Map<SessionDTO>(createdSession);
        }

        public async Task UpdateSessionAsync(int id, SessionUpdateDTO sessionUpdateDTO)
        {
            var session = await _sessionRepository.GetByIdAsync(id);
            if (session == null)
            {
                throw new Exception("Session not found.");
            }

            _mapper.Map(sessionUpdateDTO, session);
            await _sessionRepository.UpdateAsync(session);
        }
            
        public async Task DeleteSessionByIdAsync(int id)
        {
            await _sessionRepository.DeleteByIdAsync(id);
        }
    }
}
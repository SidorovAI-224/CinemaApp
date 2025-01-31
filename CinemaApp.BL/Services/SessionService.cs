using AutoMapper;
using CinemaApp.BL.DTOs.MovieDTOs;
using CinemaApp.BL.Interfaces;
using CinemaApp.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            var session = await _sessionRepository.GetByIdAsync(id);
            return _mapper.Map<SessionDTO>(session);
        }

        public async Task AddSessionAsync(SessionDTO sessionDTO)
        {
            var session = _mapper.Map<Session>(sessionDTO);
            await _sessionRepository.AddAsync(session);
        }

        public async Task UpdateSessionAsync(int id, SessionDTO sessionDTO)
        {
            var session = await _sessionRepository.GetByIdAsync(id);
            _mapper.Map(sessionDTO, session);
            await _sessionRepository.UpdateAsync(session);
        }

        public async Task DeleteSessionByIdAsync(int id)
        {
            await _sessionRepository.DeleteByIdAsync(id);
        }
    }
}

using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Services
{
    public class SessionService
    {
        private readonly IRepository<Session> _sessitoRepository;
        
        public SessionService(IRepository<Session> sessionRepository)
        {
            _sessitoRepository = sessionRepository;
        }

        public async Task<IEnumerable<Session>> GetAllSessionsAsync()
        {
            return await _sessitoRepository.GetAllAsync();
        }

        public async Task<Session> GetSessionByIdAsync(int id)
        {
            return await _sessitoRepository.GetByIdAsync(id);
        }

        public async Task AddSessionAsync(Session session)
        {
            await _sessitoRepository.AddAsync(session);
        }

        public async Task UpdateSessionAsync(Session session)
        {
            await _sessitoRepository.UpdateAsync(session);
        }

        public async Task DeleteSessionByIdAsync(int id)
        {
            await _sessitoRepository.DeleteByIdAsync(id);
        }
    }
}

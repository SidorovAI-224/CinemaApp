using CinemaApp.BL.DTOs.MovieDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Interfaces
{
    public interface ISessionService
    {
        Task<IEnumerable<SessionDTO>> GetAllSessionsAsync();
        Task<SessionDTO> GetSessionByIdAsync(int id);
        Task AddSessionAsync(SessionDTO sessionDTO);
        Task UpdateSessionAsync(int id, SessionDTO sessionDTO);
        Task DeleteSessionByIdAsync(int id);
    }
}

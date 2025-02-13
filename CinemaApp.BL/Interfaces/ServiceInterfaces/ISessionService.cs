using CinemaApp.BL.DTOs.MovieDTOs.Session;

namespace CinemaApp.BL.Interfaces
{
    public interface ISessionService
    {
        Task<IEnumerable<SessionDTO>> GetAllSessionsAsync();
        Task<SessionDTO> GetSessionByIdAsync(int id);
        Task<SessionDTO> AddSessionAsync(SessionCreateDTO sessionCreateDTO);
        Task UpdateSessionAsync(int id, SessionUpdateDTO sessionUpdateDTO);
        Task DeleteSessionByIdAsync(int id);    
    }
}
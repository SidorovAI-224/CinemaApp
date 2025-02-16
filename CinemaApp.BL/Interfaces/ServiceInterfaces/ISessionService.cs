using CinemaApp.BL.DTOs.MovieDTOs.Session;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface ISessionService
    {
        Task<IEnumerable<SessionDTO>> GetAllSessionsAsync();
        Task<SessionDTO> GetSessionByIdAsync(int id);
        Task<SessionDTO> AddSessionAsync(SessionCreateDTO sessionCreateDto);
        Task UpdateSessionAsync(int id, SessionUpdateDTO sessionUpdateDto);
        Task DeleteSessionByIdAsync(int id);
    }
}
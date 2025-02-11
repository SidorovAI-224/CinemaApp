using CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface IMoviesCrewmatesService
    {
        Task<IEnumerable<MoviesCrewmatesDTO>> GetAllMoviesCrewmatesAsync();
        Task<MoviesCrewmatesDTO> GetMoviesCrewmatesByIdAsync(int id);
        Task AddMoviesCrewmatesAsync(MoviesCrewmatesDTO moviesCrewmatesDTO);
        Task UpdateMoviesCrewmatesAsync(int id, MoviesCrewmatesDTO moviesCrewmatesDTO);
        Task DeleteMoviesCrewmatesByIdAsync(int id);
    }
}
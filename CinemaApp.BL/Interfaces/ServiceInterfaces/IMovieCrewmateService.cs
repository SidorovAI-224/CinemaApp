using CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface IMovieCrewmateService
    {
        //Task<IEnumerable<MovieCrewmateDTO>> GetAllMoviesCrewmatesAsync();
        //Task<MovieCrewmateDTO> GetMoviesCrewmatesByIdAsync(int id);
        //Task AddMoviesCrewmatesAsync(MovieCrewmateDTO moviesCrewmatesDTO);
        //Task UpdateMoviesCrewmatesAsync(int id, MovieCrewmateDTO moviesCrewmatesDTO);
        //Task DeleteMoviesCrewmatesByIdAsync(int id);


        Task AddCrewmateToMovieAsync(int movieId, int crewmateId, int positionId);
        Task RemoveCrewmateFromMovieAsync(int movieId, int crewmateId);
        Task<IEnumerable<MovieCrewmateDTO>> GetCrewmatesByMovieIdAsync(int movieId);
    }
}
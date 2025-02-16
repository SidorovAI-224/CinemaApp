using CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface IMovieCrewmateService
    {
        Task AddCrewmateToMovieAsync(int movieId, int crewmateId, int positionId);
        Task RemoveCrewmateFromMovieAsync(int movieId, int crewmateId);
        Task<IEnumerable<MovieCrewmateDTO>> GetCrewmatesByMovieIdAsync(int movieId);

        Task UpdateCrewmateInMovieAsync(int movieId, int crewmateId, int newCrewmateId, int newPositionId);
    }
}
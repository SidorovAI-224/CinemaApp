using CinemaApp.DAL.Entities;

namespace CinemaApp.DAL.Repositories.MoviesCrewmates
{
    public interface IMovieCrewmateRepository
    {
        Task<MovieCrewmate> GetByMovieAndCrewmateIdAsync(int movieId, int crewmateId);
        Task AddMovieCrewmateAsync(MovieCrewmate movieCrewmate);
        Task RemoveMovieCrewmateAsync(int movieId, int crewmateId);
        Task<IEnumerable<MovieCrewmate>> GetMovieCrewmatesByMovieIdAsync(int movieId);
        Task UpdateMovieCrewmateAsync(MovieCrewmate movieCrewmate);
    }
}
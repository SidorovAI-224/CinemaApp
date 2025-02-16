using CinemaApp.BL.DTOs.MovieDTOs.Movie;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
        Task<MovieDto> GetMovieByIdAsync(int id);
        Task AddMovieAsync(MovieCreateDto movieCreateDto);
        Task UpdateMovieAsync(int id, MovieUpdateDto movieUpdateDto);
        Task DeleteMovieByIdAsync(int id);
        Task<IEnumerable<MovieDto>> FindMovieByGenreAsync(string genre);
        Task<IEnumerable<MovieDto>> FindMovieByNameAsync(string name);

    }
}
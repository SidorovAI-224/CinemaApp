using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using CinemaApp.DAL.Entities;

namespace CinemaApp.BL.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetAllMoviesAsync();
        Task<MovieDTO> GetMovieByIdAsync(int id);
        Task AddMovieAsync(MovieCreateDTO movieCreateDTO);
        Task UpdateMovieAsync(int id, MovieUpdateDTO movieUpdateDTO);
        Task DeleteMovieByIdAsync(int id);
        Task<IEnumerable<MovieDTO>> FindMovieByGenreAsync(string genre);
        Task<IEnumerable<MovieDTO>> FindMovieByNameAsync(string name);

    }
}
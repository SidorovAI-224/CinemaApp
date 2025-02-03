using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

using CinemaApp.BL.DTOs.MovieDTOs;
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
        Task AddMovieAsync(MovieDTO movieDTO);
        Task UpdateMovieAsync(int id, MovieDTO movieDTO);
        Task DeleteMovieByIdAsync(int id);
        Task<IEnumerable<MovieDTO>> FindMovieByGenreAsync(string genre);
        Task<IEnumerable<MovieDTO>> FindMovieByNameAsync(string name);
    }
}

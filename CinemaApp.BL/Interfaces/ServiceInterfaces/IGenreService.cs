using CinemaApp.BL.DTOs.MovieDTOs.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDTO>> GetAllGenresAsync();
        Task<GenreDTO> GetGenreByIdAsync(int id);
        Task AddGenreAsync(GenreCreateDTO genreCreateDTO);
        Task UpdateGenreAsync(int id, GenreUpdateDTO genreUpdateDTO);
        Task DeleteGenreByIdAsync(int id);
    }
}
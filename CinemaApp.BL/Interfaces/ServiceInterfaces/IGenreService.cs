using CinemaApp.BL.DTOs.MovieDTOs.Genre;

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
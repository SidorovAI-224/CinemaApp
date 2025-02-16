using CinemaApp.BL.DTOs.MovieDTOs.Genre;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDto>> GetAllGenresAsync();
        Task<GenreDto> GetGenreByIdAsync(int id);
        Task AddGenreAsync(GenreCreateDto genreCreateDto);
        Task UpdateGenreAsync(int id, GenreUpdateDto genreUpdateDto);
        Task DeleteGenreByIdAsync(int id);
    }
}
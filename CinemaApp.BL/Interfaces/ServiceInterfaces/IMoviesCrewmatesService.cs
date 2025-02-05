using CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface IMoviesCrewmatesService
    {
        Task<IEnumerable<MoviesCrewmatesDTO>> GetAllMoviesCrewmatesAsync();
        Task<MoviesCrewmatesDTO> GetMoviesCrewmatesByIdAsync(int id);
        Task AddMoviesCrewmatesAsync(MoviesCrewmatesDTO moviesCrewmatesDTO);
        Task UpdateMoviesCrewmatesAsync(int id, MoviesCrewmatesDTO moviesCrewmatesDTO);
        Task DeleteMoviesCrewmatesByIdAsync(int id);
    }
}
using CinemaApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DAL.Repositories.MoviesCrewmates
{
    public interface IMovieCrewmateRepository
    {
        Task AddMovieCrewmateAsync(MovieCrewmate movieCrewmate);
        Task RemoveMovieCrewmateAsync(int movieId, int crewmateId);
        Task<IEnumerable<MovieCrewmate>> GetMovieCrewmatesByMovieIdAsync(int movieId);
    }
}

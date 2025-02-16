using CinemaApp.DAL.Data;
using CinemaApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.DAL.Repositories.MoviesCrewmates
{
    public class MovieCrewmateRepository : IMovieCrewmateRepository
    {
        private readonly CinemaDbContext _context;

        public MovieCrewmateRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<MovieCrewmate> GetByMovieAndCrewmateIdAsync(int movieId, int crewmateId)
        {
            return await _context.MovieCrewmate
                .AsNoTracking()
                .FirstOrDefaultAsync(mc => mc.MovieID == movieId && mc.CrewmateID == crewmateId);
        }

        public async Task AddMovieCrewmateAsync(MovieCrewmate movieCrewmate)
        {
            await _context.MovieCrewmate.AddAsync(movieCrewmate);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveMovieCrewmateAsync(int movieId, int crewmateId)
        {
            var movieCrewmate = await GetByMovieAndCrewmateIdAsync(movieId, crewmateId);
            if (movieCrewmate != null)
            {
                _context.MovieCrewmate.Remove(movieCrewmate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MovieCrewmate>> GetMovieCrewmatesByMovieIdAsync(int movieId)
        {
            return await _context.MovieCrewmate
                .AsNoTracking()
                .Include(mc => mc.Crewmate)
                .Include(mc => mc.Position)
                .Where(mc => mc.MovieID == movieId)
                .ToListAsync();
        }

        public async Task UpdateMovieCrewmateAsync(MovieCrewmate movieCrewmate)
        {
            _context.MovieCrewmate.Update(movieCrewmate);
            await _context.SaveChangesAsync();
        }

    }
}
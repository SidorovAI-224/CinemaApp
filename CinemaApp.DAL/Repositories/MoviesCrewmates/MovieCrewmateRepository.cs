using CinemaApp.DAL.Data;
using CinemaApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DAL.Repositories.MoviesCrewmates
{
    public class MovieCrewmateRepository : IMovieCrewmateRepository
    {
        private readonly CinemaDbContext _context;

        public MovieCrewmateRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task AddMovieCrewmateAsync(MovieCrewmate movieCrewmate)
        {
            await _context.MovieCrewmate.AddAsync(movieCrewmate);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveMovieCrewmateAsync(int movieId, int crewmateId)
        {
            var movieCrewmate = await _context.MovieCrewmate
                .FirstOrDefaultAsync(mc => mc.MovieID == movieId && mc.CrewmateID == crewmateId);

            if (movieCrewmate != null)
            {
                _context.MovieCrewmate.Remove(movieCrewmate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MovieCrewmate>> GetMovieCrewmatesByMovieIdAsync(int movieId)
        {
            return await _context.MovieCrewmate
                .Include(mc => mc.Crewmate)
                //.Include(mc => mc.Position)
                .Where(mc => mc.MovieID == movieId)
                .ToListAsync();
        }
    }
}

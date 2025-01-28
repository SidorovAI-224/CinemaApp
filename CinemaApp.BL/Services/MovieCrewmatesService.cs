using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Services
{
    public class MovieCrewmatesService
    {
        private readonly IRepository<Movies_Crewmates> _moviewCrewmatesRepository;

        public MovieCrewmatesService(IRepository<Movies_Crewmates> moviewCrewmatesRepository)
        {
            _moviewCrewmatesRepository = moviewCrewmatesRepository;
        }

        public async Task<IEnumerable<Movies_Crewmates>> GetAllMovieCrewmateAsync()
        {
            return await _moviewCrewmatesRepository.GetAllAsync();
        }

        public async Task<Movies_Crewmates> GetMovieCrewmateByIdAsync(int id)
        {
            return await _moviewCrewmatesRepository.GetByIdAsync(id);
        }

        public async Task AddMovieCrewmateAsync(Movies_Crewmates genre)
        {
            await _moviewCrewmatesRepository.AddAsync(genre);
        }

        public async Task UpdateMovieCrewmateAsync(Movies_Crewmates genre)
        {
            await _moviewCrewmatesRepository.UpdateAsync(genre);
        }

        public async Task DeleteMovieCrewmateByIdAsync(int id)
        {
            await _moviewCrewmatesRepository.DeleteByIdAsync(id);
        }
    }
}

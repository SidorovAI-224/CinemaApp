using AutoMapper;
using CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.DAL.Entities;

namespace CinemaApp.BL.Services
{
    public class MovieCrewmateService : IMovieCrewmateService
    {
        private readonly IRepository<MovieCrewmate> _moviewCrewmatesRepository;
        private readonly IMapper _mapper;

        public MovieCrewmateService(IRepository<MovieCrewmate> moviewCrewmatesRepository, IMapper mapper)
        {
            _moviewCrewmatesRepository = moviewCrewmatesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieCrewmateDTO>> GetAllMoviesCrewmatesAsync()
        {
            var moviesCrewmates = await _moviewCrewmatesRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MovieCrewmateDTO>>(moviesCrewmates);
        }

        public async Task<MovieCrewmateDTO> GetMoviesCrewmatesByIdAsync(int id)
        {
            var moviesCrewmates = await _moviewCrewmatesRepository.GetByIdAsync(id);
            return _mapper.Map<MovieCrewmateDTO>(moviesCrewmates);
        }

        public async Task AddMoviesCrewmatesAsync(MovieCrewmateDTO movies_CrewmatesDTO)
        {
            var moviesCrewmates = _mapper.Map<MovieCrewmate>(movies_CrewmatesDTO);
            await _moviewCrewmatesRepository.AddAsync(moviesCrewmates);
        }

        public async Task UpdateMoviesCrewmatesAsync(int id, MovieCrewmateDTO moviesCrewmatesDTO)
        {
            var moviesCrewmates = await _moviewCrewmatesRepository.GetByIdAsync(id);
            _mapper.Map(moviesCrewmatesDTO, moviesCrewmates);
            await _moviewCrewmatesRepository.UpdateAsync(moviesCrewmates);
        }

        public async Task DeleteMoviesCrewmatesByIdAsync(int id)
        {
            await _moviewCrewmatesRepository.DeleteByIdAsync(id);
        }
    }
}
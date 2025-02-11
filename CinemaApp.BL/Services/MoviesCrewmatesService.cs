using AutoMapper;
using CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.DAL.Entities;

namespace CinemaApp.BL.Services
{
    public class MoviesCrewmatesService : IMoviesCrewmatesService
    {
        private readonly IRepository<MoviesCrewmates> _moviewCrewmatesRepository;
        private readonly IMapper _mapper;

        public MoviesCrewmatesService(IRepository<MoviesCrewmates> moviewCrewmatesRepository, IMapper mapper)
        {
            _moviewCrewmatesRepository = moviewCrewmatesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MoviesCrewmatesDTO>> GetAllMoviesCrewmatesAsync()
        {
            var moviesCrewmates = await _moviewCrewmatesRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MoviesCrewmatesDTO>>(moviesCrewmates);
        }

        public async Task<MoviesCrewmatesDTO> GetMoviesCrewmatesByIdAsync(int id)
        {
            var moviesCrewmates = await _moviewCrewmatesRepository.GetByIdAsync(id);
            return _mapper.Map<MoviesCrewmatesDTO>(moviesCrewmates);
        }

        public async Task AddMoviesCrewmatesAsync(MoviesCrewmatesDTO movies_CrewmatesDTO)
        {
            var moviesCrewmates = _mapper.Map<MoviesCrewmates>(movies_CrewmatesDTO);
            await _moviewCrewmatesRepository.AddAsync(moviesCrewmates);
        }

        public async Task UpdateMoviesCrewmatesAsync(int id, MoviesCrewmatesDTO moviesCrewmatesDTO)
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
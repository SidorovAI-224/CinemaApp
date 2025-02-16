using AutoMapper;
using CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Repositories.MoviesCrewmates;

namespace CinemaApp.BL.Services
{
    public class MovieCrewmateService : IMovieCrewmateService
    {
        private readonly IMovieCrewmateRepository _movieCrewmateRepository;
        private readonly ICrewmateService _crewmateService;
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;

        public MovieCrewmateService(IMovieCrewmateRepository movieCrewmateRepository, IMapper mapper, ICrewmateService crewmateService, IPositionService positionService)
        {
            _movieCrewmateRepository = movieCrewmateRepository;
            _mapper = mapper;
            _crewmateService = crewmateService;
            _positionService = positionService; 
        }
       
        public async Task AddCrewmateToMovieAsync(int movieId, int crewmateId, int positionId)
        {
            var crewmateExists = await _crewmateService.GetCrewmateByIdAsync(crewmateId);
            var positionExists = await _positionService.GetPositionByIdAsync(positionId);

            if (crewmateExists == null || positionExists == null)
            {
                throw new Exception("Invalid CrewmateID or PositionID");
            }

            var movieCrewmate = new MovieCrewmate
            {
                MovieId = movieId,
                CrewmateId = crewmateId,
                PositionId = positionId
            };

            await _movieCrewmateRepository.AddMovieCrewmateAsync(movieCrewmate);
        }
        public async Task RemoveCrewmateFromMovieAsync(int movieId, int crewmateId)
        {
            var movieCrewmate = await _movieCrewmateRepository.GetByMovieAndCrewmateIdAsync(movieId, crewmateId);
            if (movieCrewmate != null)
            {
                await _movieCrewmateRepository.RemoveMovieCrewmateAsync(movieId, crewmateId);
            }
        }

        public async Task<IEnumerable<MovieCrewmateDTO>> GetCrewmatesByMovieIdAsync(int movieId)
        {
            var movieCrewmates = await _movieCrewmateRepository.GetMovieCrewmatesByMovieIdAsync(movieId);
            return _mapper.Map<IEnumerable<MovieCrewmateDTO>>(movieCrewmates);
        }

        public async Task UpdateCrewmateInMovieAsync(int movieId, int crewmateId, int newCrewmateId, int newPositionId)
        {
            var movieCrewmate = await _movieCrewmateRepository.GetByMovieAndCrewmateIdAsync(movieId, crewmateId);
            if (movieCrewmate != null)
            {
                movieCrewmate.CrewmateId = newCrewmateId;
                movieCrewmate.PositionId = newPositionId;

                await _movieCrewmateRepository.UpdateMovieCrewmateAsync(movieCrewmate);
            }
        }

    }
}
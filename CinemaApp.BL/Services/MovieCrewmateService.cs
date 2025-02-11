using AutoMapper;
using CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Repositories.MoviesCrewmates;

namespace CinemaApp.BL.Services
{
    public class MovieCrewmateService : IMovieCrewmateService
    {
        private readonly IMovieCrewmateRepository _movieCrewmateRepository;
        private readonly IMapper _mapper;

        public MovieCrewmateService(IMovieCrewmateRepository movieCrewmateRepository, IMapper mapper)
        {
            _movieCrewmateRepository = movieCrewmateRepository;
            _mapper = mapper;
        }

        public async Task AddCrewmateToMovieAsync(int movieId, int crewmateId, int positionId)
        {
            var movieCrewmate = new MovieCrewmate
            {
                MovieID = movieId,
                CrewmateID = crewmateId,
                PositionID = positionId
            };

            await _movieCrewmateRepository.AddMovieCrewmateAsync(movieCrewmate);
        }

        public async Task RemoveCrewmateFromMovieAsync(int movieId, int crewmateId)
        {
            await _movieCrewmateRepository.RemoveMovieCrewmateAsync(movieId, crewmateId);
        }

        public async Task<IEnumerable<MovieCrewmateDTO>> GetCrewmatesByMovieIdAsync(int movieId)
        {
            var movieCrewmates = await _movieCrewmateRepository.GetMovieCrewmatesByMovieIdAsync(movieId);
            return _mapper.Map<IEnumerable<MovieCrewmateDTO>>(movieCrewmates);
        }
    }
}
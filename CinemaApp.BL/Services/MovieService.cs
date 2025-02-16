using AutoMapper;
using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Repositories;
using CinemaApp.DAL.Repositories.MoviesCrewmates;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.BL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IMovieCrewmateRepository _movieCrewmateRepository;
        private readonly IMapper _mapper;
        private readonly IGenreService _genreService;
        public MovieService(IRepository<Movie> movieRepository, IMapper mapper, IMovieCrewmateRepository movieCrewmateRepository, IGenreService genreService)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _movieCrewmateRepository = movieCrewmateRepository;
            _genreService = genreService;
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }

        public async Task<MovieDto> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id,
                include: q => q.Include(m => m.MovieCrewmates)
                               .ThenInclude(mc => mc.Crewmate)
                               .Include(m => m.MovieCrewmates)
                               .ThenInclude(mc => mc.Position)
                               .Include(m => m.Genre)
                               .Include(m => m.Genre1)
                               .Include(m => m.Genre2)
                               .Include(m => m.Genre3)
                               .Include(m => m.Genre4)
                               .AsNoTracking()
            );

            var movieDto = _mapper.Map<MovieDto>(movie);

            if (movie.Genre != null)
            {
                movieDto.GenreName = movie.Genre.GenreName;
            }
            if (movie.Genre1 != null)
            {
                movieDto.GenreName1 = movie.Genre1.GenreName;
            }
            if (movie.Genre2 != null)
            {
                movieDto.GenreName2 = movie.Genre2.GenreName;
            }
            if (movie.Genre3 != null)
            {
                movieDto.GenreName3 = movie.Genre3.GenreName;
            }
            if (movie.Genre4 != null)
            {
                movieDto.GenreName4 = movie.Genre4.GenreName;
            }

            return movieDto;
        }

        public async Task AddMovieAsync(MovieCreateDto movieCreateDto)
        {
            var movie = _mapper.Map<Movie>(movieCreateDto);
            if (movieCreateDto.GenreId.HasValue)
            {
                var genre1 = await _genreService.GetGenreByIdAsync(movieCreateDto.GenreId.Value);
                if (genre1 == null)
                {
                    throw new Exception($"Genre with ID {movieCreateDto.GenreId} does not exist.");
                }
            }
            if (movieCreateDto.GenreId1.HasValue)
            {
                var genre1 = await _genreService.GetGenreByIdAsync(movieCreateDto.GenreId1.Value);
                if (genre1 == null)
                {
                    throw new Exception($"Genre with ID {movieCreateDto.GenreId1} does not exist.");
                }
            }

            if (movieCreateDto.GenreId2.HasValue)
            {
                var genre2 = await _genreService.GetGenreByIdAsync(movieCreateDto.GenreId2.Value);
                if (genre2 == null)
                {
                    throw new Exception($"Genre with ID {movieCreateDto.GenreId2} does not exist.");
                }
            }

            if (movieCreateDto.GenreId3.HasValue)
            {
                var genre3 = await _genreService.GetGenreByIdAsync(movieCreateDto.GenreId3.Value);
                if (genre3 == null)
                {
                    throw new Exception($"Genre with ID {movieCreateDto.GenreId3} does not exist.");
                }
            }

            if (movieCreateDto.GenreId4.HasValue)
            {
                var genre4 = await _genreService.GetGenreByIdAsync(movieCreateDto.GenreId4.Value);
                if (genre4 == null)
                {
                    throw new Exception($"Genre with ID {movieCreateDto.GenreId4} does not exist.");
                }
            }

            await _movieRepository.AddAsync(movie);

            if (movieCreateDto.MovieCrewmates != null)
            {
                foreach (var crewmateDto in movieCreateDto.MovieCrewmates)
                {
                    var existingCrewmate = await _movieCrewmateRepository.GetByMovieAndCrewmateIdAsync(movie.MovieId, crewmateDto.CrewmateID);
                    if (existingCrewmate == null)
                    {
                        var movieCrewmate = new MovieCrewmate
                        {
                            MovieId = movie.MovieId,
                            CrewmateId = crewmateDto.CrewmateID,
                            PositionId = crewmateDto.PositionID
                        };

                        await _movieCrewmateRepository.AddMovieCrewmateAsync(movieCrewmate);
                    }
                }
            }
        }
        public async Task UpdateMovieAsync(int id, MovieUpdateDto movieUpdateDto)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                throw new Exception("Movie not found");
            }

            movie.Title = movieUpdateDto.Title;
            movie.Description = movieUpdateDto.Description;
            movie.GenreId = movieUpdateDto.GenreId;
            movie.GenreId1 = movieUpdateDto.GenreId1;
            movie.GenreId2 = movieUpdateDto.GenreId2;
            movie.GenreId3 = movieUpdateDto.GenreId3;
            movie.GenreId4 = movieUpdateDto.GenreId4;
            movie.Duration = movieUpdateDto.Duration;
            movie.ReleaseDate = movieUpdateDto.ReleaseDate;
            movie.Rating = movieUpdateDto.Rating;
            movie.AgeLimit = movieUpdateDto.AgeLimit;
            movie.PosterUrl = movieUpdateDto.PosterUrl;
            movie.TrailerUrl = movieUpdateDto.TrailerUrl;

            var existingCrewmates = await _movieCrewmateRepository.GetMovieCrewmatesByMovieIdAsync(id);
            foreach (var crewmate in existingCrewmates)
            {
                await _movieCrewmateRepository.RemoveMovieCrewmateAsync(crewmate.MovieId, crewmate.CrewmateId);
            }

            if (movieUpdateDto.MovieCrewmates != null)
            {
                foreach (var crewmateDto in movieUpdateDto.MovieCrewmates)
                {
                    var movieCrewmate = new MovieCrewmate
                    {
                        MovieId = movie.MovieId,
                        CrewmateId = crewmateDto.CrewmateID,
                        PositionId = crewmateDto.PositionID
                    };

                    await _movieCrewmateRepository.AddMovieCrewmateAsync(movieCrewmate);
                }
            }

            await _movieRepository.UpdateAsync(movie);
        }

        public async Task DeleteMovieByIdAsync(int id)
        {
            await _movieRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<MovieDto>> FindMovieByGenreAsync(string genre)
        {
            var movies = await _movieRepository.FindAsync(m => m.Genre.GenreName == genre);
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }

        public async Task<IEnumerable<MovieDto>> FindMovieByNameAsync(string name)
        {
            var movies = await _movieRepository.FindAsync(m => m.Title != null && m.Title.Contains(name));
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }
    }
}

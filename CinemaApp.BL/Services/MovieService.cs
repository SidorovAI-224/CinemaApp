using AutoMapper;
using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.DAL.Entities;
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

        public async Task<IEnumerable<MovieDTO>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MovieDTO>>(movies);
        }

        public async Task<MovieDTO> GetMovieByIdAsync(int id)
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

            var movieDTO = _mapper.Map<MovieDTO>(movie);

            if (movie.Genre != null)
            {
                movieDTO.GenreName = movie.Genre.GenreName;
            }
            if (movie.Genre1 != null)
            {
                movieDTO.GenreName1 = movie.Genre1.GenreName;
            }
            if (movie.Genre2 != null)
            {
                movieDTO.GenreName2 = movie.Genre2.GenreName;
            }
            if (movie.Genre3 != null)
            {
                movieDTO.GenreName3 = movie.Genre3.GenreName;
            }
            if (movie.Genre4 != null)
            {
                movieDTO.GenreName4 = movie.Genre4.GenreName;
            }

            return movieDTO;
        }

        public async Task AddMovieAsync(MovieCreateDTO movieCreateDTO)
        {
            var movie = _mapper.Map<Movie>(movieCreateDTO);
            if (movieCreateDTO.GenreID.HasValue)
            {
                var genre1 = await _genreService.GetGenreByIdAsync(movieCreateDTO.GenreID.Value);
                if (genre1 == null)
                {
                    throw new Exception($"Genre with ID {movieCreateDTO.GenreID} does not exist.");
                }
            }
            if (movieCreateDTO.GenreID1.HasValue)
            {
                var genre1 = await _genreService.GetGenreByIdAsync(movieCreateDTO.GenreID1.Value);
                if (genre1 == null)
                {
                    throw new Exception($"Genre with ID {movieCreateDTO.GenreID1} does not exist.");
                }
            }

            if (movieCreateDTO.GenreID2.HasValue)
            {
                var genre2 = await _genreService.GetGenreByIdAsync(movieCreateDTO.GenreID2.Value);
                if (genre2 == null)
                {
                    throw new Exception($"Genre with ID {movieCreateDTO.GenreID2} does not exist.");
                }
            }

            if (movieCreateDTO.GenreID3.HasValue)
            {
                var genre3 = await _genreService.GetGenreByIdAsync(movieCreateDTO.GenreID3.Value);
                if (genre3 == null)
                {
                    throw new Exception($"Genre with ID {movieCreateDTO.GenreID3} does not exist.");
                }
            }

            if (movieCreateDTO.GenreID4.HasValue)
            {
                var genre4 = await _genreService.GetGenreByIdAsync(movieCreateDTO.GenreID4.Value);
                if (genre4 == null)
                {
                    throw new Exception($"Genre with ID {movieCreateDTO.GenreID4} does not exist.");
                }
            }

            await _movieRepository.AddAsync(movie);

            if (movieCreateDTO.MovieCrewmates != null)
            {
                foreach (var crewmateDTO in movieCreateDTO.MovieCrewmates)
                {
                    var existingCrewmate = await _movieCrewmateRepository.GetByMovieAndCrewmateIdAsync(movie.MovieID, crewmateDTO.CrewmateID);
                    if (existingCrewmate == null)
                    {
                        var movieCrewmate = new MovieCrewmate
                        {
                            MovieID = movie.MovieID,
                            CrewmateID = crewmateDTO.CrewmateID,
                            PositionID = crewmateDTO.PositionID
                        };

                        await _movieCrewmateRepository.AddMovieCrewmateAsync(movieCrewmate);
                    }
                }
            }
        }
        public async Task UpdateMovieAsync(int id, MovieUpdateDTO movieUpdateDTO)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                throw new Exception("Movie not found");
            }

            movie.Title = movieUpdateDTO.Title;
            movie.Description = movieUpdateDTO.Description;
            movie.GenreID = movieUpdateDTO.GenreID;
            movie.GenreID1 = movieUpdateDTO.GenreID1;
            movie.GenreID2 = movieUpdateDTO.GenreID2;
            movie.GenreID3 = movieUpdateDTO.GenreID3;
            movie.GenreID4 = movieUpdateDTO.GenreID4;
            movie.Duration = movieUpdateDTO.Duration;
            movie.ReleaseDate = movieUpdateDTO.ReleaseDate;
            movie.Rating = movieUpdateDTO.Rating;
            movie.AgeLimit = movieUpdateDTO.AgeLimit;
            movie.PosterURL = movieUpdateDTO.PosterURL;
            movie.TrailerURL = movieUpdateDTO.TrailerURL;

            var existingCrewmates = await _movieCrewmateRepository.GetMovieCrewmatesByMovieIdAsync(id);
            foreach (var crewmate in existingCrewmates)
            {
                await _movieCrewmateRepository.RemoveMovieCrewmateAsync(crewmate.MovieID, crewmate.CrewmateID);
            }

            if (movieUpdateDTO.MovieCrewmates != null)
            {
                foreach (var crewmateDTO in movieUpdateDTO.MovieCrewmates)
                {
                    var movieCrewmate = new MovieCrewmate
                    {
                        MovieID = movie.MovieID,
                        CrewmateID = crewmateDTO.CrewmateID,
                        PositionID = crewmateDTO.PositionID
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

        public async Task<IEnumerable<MovieDTO>> FindMovieByGenreAsync(string genre)
        {
            var movies = await _movieRepository.FindAsync(m => m.Genre.GenreName == genre);
            return _mapper.Map<IEnumerable<MovieDTO>>(movies);
        }

        public async Task<IEnumerable<MovieDTO>> FindMovieByNameAsync(string name)
        {
            var movies = await _movieRepository.FindAsync(m => m.Title.Contains(name));
            return _mapper.Map<IEnumerable<MovieDTO>>(movies);
        }
    }
}

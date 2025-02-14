using AutoMapper;
using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using CinemaApp.BL.Interfaces;
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

        public MovieService(IRepository<Movie> movieRepository, IMapper mapper, IMovieCrewmateRepository movieCrewmateRepository)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _movieCrewmateRepository = movieCrewmateRepository;
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
                               .AsNoTracking()
            );

            var movieDTO = _mapper.Map<MovieDTO>(movie);
            movieDTO.GenreName = movie.Genre?.GenreName; 
            return movieDTO;
        }

        public async Task AddMovieAsync(MovieCreateDTO movieCreateDTO)
        {
            var movie = _mapper.Map<Movie>(movieCreateDTO);

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

        //public async Task UpdateMovieAsync(int id, MovieUpdateDTO movieUpdateDTO)
        //{
        //    var movie = await _movieRepository.GetByIdAsync(id);
        //    if (movie == null)
        //    {
        //        throw new Exception("Movie not found");
        //    }

        //    movie.Title = movieUpdateDTO.Title;
        //    movie.Description = movieUpdateDTO.Description;
        //    movie.GenreID = movieUpdateDTO.GenreID;
        //    movie.Duration = movieUpdateDTO.Duration;
        //    movie.ReleaseDate = movieUpdateDTO.ReleaseDate;
        //    movie.Rating = movieUpdateDTO.Rating;
        //    movie.AgeLimit = movieUpdateDTO.AgeLimit;
        //    movie.PosterURL = movieUpdateDTO.PosterURL;
        //    movie.TrailerURL = movieUpdateDTO.TrailerURL;

        //    var existingCrewmates = await _movieCrewmateRepository.GetMovieCrewmatesByMovieIdAsync(id);
        //    foreach (var crewmate in existingCrewmates)
        //    {
        //        await _movieCrewmateRepository.RemoveMovieCrewmateAsync(crewmate.MovieID, crewmate.CrewmateID);
        //    }

        //    if (movieUpdateDTO.MovieCrewmates != null)
        //    {
        //        foreach (var crewmateDTO in movieUpdateDTO.MovieCrewmates)
        //        {
        //            var movieCrewmate = new MovieCrewmate
        //            {
        //                MovieID = movie.MovieID,
        //                CrewmateID = crewmateDTO.CrewmateID,
        //                PositionID = crewmateDTO.PositionID
        //            };

        //            await _movieCrewmateRepository.AddMovieCrewmateAsync(movieCrewmate);
        //        }
        //    }

        //    await _movieRepository.UpdateAsync(movie);
        //}
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

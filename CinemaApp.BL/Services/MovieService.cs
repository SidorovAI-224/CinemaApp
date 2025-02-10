using AutoMapper;
using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using CinemaApp.BL.Interfaces;
using CinemaApp.DAL.Entities;

namespace CinemaApp.BL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Genre> _genreRepository;
        private readonly IMapper _mapper;

        public MovieService(IRepository<Movie> movieRepository, IRepository<Genre> genreRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDTO>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MovieDTO>>(movies);
        }

        public async Task<MovieDTO> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return _mapper.Map<MovieDTO>(movie);
        }

        public async Task AddMovieAsync(MovieCreateDTO movieDTO)
        {
            var genre = await _genreRepository.GetByIdAsync(movieDTO.GenreID);
            if (genre == null)
            {
                throw new Exception("Жанр з таким ID не знайдено.");
            }

            var movie = _mapper.Map<Movie>(movieDTO);
            await _movieRepository.AddAsync(movie);
        }

        public async Task UpdateMovieAsync(int id, MovieUpdateDTO movieDTO)
        {
            var genre = await _genreRepository.GetByIdAsync(movieDTO.GenreID);
            if (genre == null)
            {
                throw new Exception("Жанр з таким ID не знайдено.");
            }

            var movie = await _movieRepository.GetByIdAsync(id);
            _mapper.Map(movieDTO, movie);
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


using AutoMapper;
using CinemaApp.DAL.Entities;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.DTOs.MovieDTOs.Movie;

namespace CinemaApp.BL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IRepository<Movie> movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
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

        public async Task AddMovieAsync(MovieCreateDTO movieCreateDTO)
        {
            var movie = _mapper.Map<Movie>(movieCreateDTO);
            await _movieRepository.AddAsync(movie);
        }

        public async Task UpdateMovieAsync(int id, MovieUpdateDTO movieUpdateDTO)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            _mapper.Map(movieUpdateDTO, movie);
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

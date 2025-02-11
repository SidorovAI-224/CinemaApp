using AutoMapper;
using CinemaApp.DAL.Entities;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.DTOs.MovieDTOs.Genre;

namespace CinemaApp.BL.Services
{
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IRepository<Genre> genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDTO>> GetAllGenresAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GenreDTO>>(genres);
        }

        public async Task<GenreDTO> GetGenreByIdAsync(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            return _mapper.Map<GenreDTO>(genre);
        }

        public async Task AddGenreAsync(GenreCreateDTO genreCreateDTO)
        {
            var genre = _mapper.Map<Genre>(genreCreateDTO);
            await _genreRepository.AddAsync(genre);
        }

        public async Task UpdateGenreAsync(int id, GenreUpdateDTO genreUpdateDTO)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            _mapper.Map(genreUpdateDTO, genre);
            await _genreRepository.UpdateAsync(genre);
        }

        public async Task DeleteGenreByIdAsync(int id)
        {
            await _genreRepository.DeleteByIdAsync(id);
        }
    }
}



using AutoMapper;
using CinemaApp.DAL.Entities;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.DTOs.MovieDTOs.Genre;
using CinemaApp.DAL.Repositories;

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

        public async Task<IEnumerable<GenreDto>> GetAllGenresAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GenreDto>>(genres);
        }

        public async Task<GenreDto> GetGenreByIdAsync(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            return _mapper.Map<GenreDto>(genre);
        }

        public async Task AddGenreAsync(GenreCreateDto genreCreateDto)
        {
            var genre = _mapper.Map<Genre>(genreCreateDto);
            await _genreRepository.AddAsync(genre);
        }

        public async Task UpdateGenreAsync(int id, GenreUpdateDto genreUpdateDto)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            _mapper.Map(genreUpdateDto, genre);
            await _genreRepository.UpdateAsync(genre);
        }

        public async Task DeleteGenreByIdAsync(int id)
        {
            await _genreRepository.DeleteByIdAsync(id);
        }
    }
}



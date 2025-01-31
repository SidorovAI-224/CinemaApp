using AutoMapper;
using CinemaApp.BL.DTOs.MovieDTOs;
using CinemaApp.DAL.Entities;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task AddGenreAsync(GenreDTO genreDTO)
        {
            var genre = _mapper.Map<Genre>(genreDTO);
            await _genreRepository.AddAsync(genre);
        }

        public async Task UpdateGenreAsync(int id, GenreDTO genreDTO)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            _mapper.Map(genreDTO, genre);
            await _genreRepository.UpdateAsync(genre);
        }

        public async Task DeleteGenreByIdAsync(int id)
        {
            await _genreRepository.DeleteByIdAsync(id);
        }
    }
}



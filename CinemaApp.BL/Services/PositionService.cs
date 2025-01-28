using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Services
{
    public class PositionService
    {
        private readonly IRepository<Position> _positionRepository;

        public PositionService(IRepository<Position> positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync()
        {
            return await _positionRepository.GetAllAsync();
        }

        public async Task<Position> GetPositionByIdAsync(int id)
        {
            return await _positionRepository.GetByIdAsync(id);
        }

        public async Task AddPositionAsync(Position movie)
        {
            await _positionRepository.AddAsync(movie);
        }

        public async Task UpdatePositionAsync(Position position)
        {
            await _positionRepository.UpdateAsync(position);
        }

        public async Task DeletePositionByIdAsync(int id)
        {
            await _positionRepository.DeleteByIdAsync(id);
        }
    }
}

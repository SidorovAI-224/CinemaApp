using AutoMapper;
using CinemaApp.BL.DTOs.CrewDTOs.Position;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Services
{
    public class PositionService : IPositionService
    {
        private readonly IRepository<Position> _positionRepository;
        private readonly IMapper _mapper;

        public PositionService(IRepository<Position> positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<PositionDTO>> GetAllPositionsAsync()
        {
            var positions = await _positionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PositionDTO>>(positions);
        }

        public async Task<PositionDTO> GetPositionByIdAsync(int id)
        {
            var position = await _positionRepository.GetByIdAsync(id);
            return _mapper.Map<PositionDTO>(position);
        }

        public async Task AddPositionAsync(PositionCreateDTO positionCreateDTO)
        {
            var position = _mapper.Map<Position>(positionCreateDTO);
            await _positionRepository.AddAsync(position);
        }

        public async Task UpdatePositionAsync(int id, PositionUpdateDTO positionUpdateDTO)
        {
            var position = await _positionRepository.GetByIdAsync(id);
            _mapper.Map(positionUpdateDTO, position);
            await _positionRepository.UpdateAsync(position);
        }

        public async Task DeletePositionByIdAsync(int id)
        {
            await _positionRepository.DeleteByIdAsync(id);
        }
    }
}
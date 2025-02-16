using AutoMapper;
using CinemaApp.BL.DTOs.CrewDTOs.Position;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Repositories;

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

        public async Task<IEnumerable<PositionDto>> GetAllPositionsAsync()
        {
            var positions = await _positionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PositionDto>>(positions);
        }

        public async Task<PositionDto> GetPositionByIdAsync(int id)
        {
            var position = await _positionRepository.GetByIdAsync(id);
            return _mapper.Map<PositionDto>(position);
        }

        public async Task AddPositionAsync(PositionCreateDto positionCreateDto)
        {
            var position = _mapper.Map<Position>(positionCreateDto);
            await _positionRepository.AddAsync(position);
        }

        public async Task UpdatePositionAsync(int id, PositionUpdateDto positionUpdateDto)
        {
            var position = await _positionRepository.GetByIdAsync(id);
            _mapper.Map(positionUpdateDto, position);
            await _positionRepository.UpdateAsync(position);
        }

        public async Task DeletePositionByIdAsync(int id)
        {
            await _positionRepository.DeleteByIdAsync(id);
        }
    }
}
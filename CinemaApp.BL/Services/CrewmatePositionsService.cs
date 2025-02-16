using AutoMapper;
using CinemaApp.BL.DTOs.CrewDTOs.CrewmatePositions;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Repositories;

namespace CinemaApp.BL.Services
{
    public class CrewmatePositionsService : ICrewmatePositionsService
    {
        private readonly IRepository<CrewmatePositions> _crewmatePositionsRepository;
        private readonly IMapper _mapper;


        public CrewmatePositionsService(IRepository<CrewmatePositions> crewmatePositionsRepository, IMapper mapper)
        {
            _crewmatePositionsRepository = crewmatePositionsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CrewmatePositionsDto>> GetAllCrewmatePositionsAsync()
        {
            var crewmatePositions = await _crewmatePositionsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CrewmatePositionsDto>>(crewmatePositions);
        }

        public async Task<CrewmatePositionsDto> GetCrewmatePositionsByIdAsync(int id)
        {
            var crewmatePositions = await _crewmatePositionsRepository.GetByIdAsync(id);
            return _mapper.Map<CrewmatePositionsDto>(crewmatePositions);
        }

        public async Task AddCrewmatePositionsAsync(CrewmatePositionsDto crewmatePositionsDto)
        {
            var crewmatePositions = _mapper.Map<CrewmatePositions>(crewmatePositionsDto);
            await _crewmatePositionsRepository.AddAsync(crewmatePositions);
        }

        public async Task UpdateCrewmatePositionsAsync(int id, CrewmatePositionsDto crewmatePositionDto)
        {
            var crewmate = await _crewmatePositionsRepository.GetByIdAsync(id);
            _mapper.Map(crewmatePositionDto, crewmate);
            await _crewmatePositionsRepository.UpdateAsync(crewmate);
        }

        public async Task DeleteCrewmatePositionsByIdAsync(int id)
        {
            await _crewmatePositionsRepository.DeleteByIdAsync(id);
        }
    }
}

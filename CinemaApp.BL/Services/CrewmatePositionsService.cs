using AutoMapper;
using CinemaApp.BL.DTOs.CrewDTOs.CrewmatePositions;
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
    public class CrewmatePositionsService : ICrewmatePositionsService
    {
        private readonly IRepository<Crewmate_Positions> _crewmatePositionsRepository;
        private readonly IMapper _mapper;


        public CrewmatePositionsService(IRepository<Crewmate_Positions> crewmatePositionsRepository, IMapper mapper)
        {
            _crewmatePositionsRepository = crewmatePositionsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CrewmatePositionsDTO>> GetAllCrewmatePositionsAsync()
        {
            var crewmatePositions = await _crewmatePositionsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CrewmatePositionsDTO>>(crewmatePositions);
        }

        public async Task<CrewmatePositionsDTO> GetCrewmatePositionsByIdAsync(int id)
        {
            var crewmatePositions = await _crewmatePositionsRepository.GetByIdAsync(id);
            return _mapper.Map<CrewmatePositionsDTO>(crewmatePositions);
        }

        public async Task AddCrewmatePositionsAsync(CrewmatePositionsDTO crewmatePositionsDTO)
        {
            var crewmatePositions = _mapper.Map<Crewmate_Positions>(crewmatePositionsDTO);
            await _crewmatePositionsRepository.AddAsync(crewmatePositions);
        }

        public async Task UpdateCrewmatePositionsAsync(int id, CrewmatePositionsDTO crewmatePositionDTO)
        {
            var crewmate = await _crewmatePositionsRepository.GetByIdAsync(id);
            _mapper.Map(crewmatePositionDTO, crewmate);
            await _crewmatePositionsRepository.UpdateAsync(crewmate);
        }

        public async Task DeleteCrewmatePositionsByIdAsync(int id)
        {
            await _crewmatePositionsRepository.DeleteByIdAsync(id);
        }
    }
}

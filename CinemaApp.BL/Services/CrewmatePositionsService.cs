using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Services
{
    public class CrewmatePositionsService
    {
        private readonly IRepository<Crewmate_Positions> _crewmatePositionsRepository;

        public CrewmatePositionsService(IRepository<Crewmate_Positions> crewmatePositionsRepository)
        {
            _crewmatePositionsRepository = crewmatePositionsRepository;
        }

        public async Task<IEnumerable<Crewmate_Positions>> GetAllCrewmatePositionsAsync()
        {
            return await _crewmatePositionsRepository.GetAllAsync();
        }

        public async Task<Crewmate_Positions> GetCrewmatePositionByIdAsync(int id)
        {
            return await _crewmatePositionsRepository.GetByIdAsync(id);
        }

        public async Task AddCrewmatePositionsAsync(Crewmate_Positions crewmatePositions)
        {
            await _crewmatePositionsRepository.AddAsync(crewmatePositions);
        }

        public async Task UpdateCrewmatePositionsAsync(Crewmate_Positions crewmatePosition)
        {
            await _crewmatePositionsRepository.UpdateAsync(crewmatePosition);
        }

        public async Task DeleteCrewmatePositionsByIdAsync(int id)
        {
            await _crewmatePositionsRepository.DeleteByIdAsync(id);
        }
    }
}

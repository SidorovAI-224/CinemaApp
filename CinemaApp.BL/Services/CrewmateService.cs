using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Services
{
    public class CrewmateService
    {
        private readonly IRepository<Crewmate> _crewmateRepository;

        public CrewmateService(IRepository<Crewmate> crewmateRepository)
        {
            _crewmateRepository = crewmateRepository;
        }

        public async Task<IEnumerable<Crewmate>> GetAllCrewmatesAsync()
        {
            return await _crewmateRepository.GetAllAsync();
        }

        public async Task<Crewmate> GetCrewmateByIdAsync(int id)
        {
            return await _crewmateRepository.GetByIdAsync(id);
        }

        public async Task AddCrewmateAsync(Crewmate crewmate)
        {
            await _crewmateRepository.AddAsync(crewmate);
        }

        public async Task UpdateCrewmateAsync(Crewmate crewmate)
        {
            await _crewmateRepository.UpdateAsync(crewmate);
        }

        public async Task DeleteCrewmateByIdAsync(int id)
        {
            await _crewmateRepository.DeleteByIdAsync(id);
        }
    }
}

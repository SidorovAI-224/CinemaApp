using AutoMapper;
using CinemaApp.BL.DTOs.CrewDTOs.Crewmate;
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
    public class CrewmateService : ICrewmateService
    {
        private readonly IRepository<Crewmate> _crewmateRepository;
        private readonly IMapper _mapper;

        public CrewmateService(IRepository<Crewmate> crewmateRepository, IMapper mapper)
        {
            _crewmateRepository = crewmateRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CrewmateDTO>> GetAllCrewmatesAsync()
        {
            var crewmates = await _crewmateRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CrewmateDTO>>(crewmates);
        }

        public async Task<CrewmateDTO> GetCrewmateByIdAsync(int id)
        {
            var crewmate = await _crewmateRepository.GetByIdAsync(id);
            return _mapper.Map<CrewmateDTO>(crewmate);
        }

        public async Task AddCrewmateAsync(CrewmateCreateDTO crewmateCreateDTO)
        {
            var crewmate = _mapper.Map<Crewmate>(crewmateCreateDTO);
            await _crewmateRepository.AddAsync(crewmate);
        }

        public async Task UpdateCrewmateAsync(int id, CrewmateUpdateDTO crewmateUpdateDTO)
        {
            var crewmate = await _crewmateRepository.GetByIdAsync(id);
            _mapper.Map(crewmateUpdateDTO, crewmate);
            await _crewmateRepository.UpdateAsync(crewmate);
        }

        public async Task DeleteCrewmateByIdAsync(int id)
        {
            await _crewmateRepository.DeleteByIdAsync(id);
        }
    }
}

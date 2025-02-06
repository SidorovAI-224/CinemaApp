using CinemaApp.BL.DTOs.CrewDTOs.Crewmate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface ICrewmateService
    {
        Task<IEnumerable<CrewmateDTO>> GetAllCrewmatesAsync();
        Task<CrewmateDTO> GetCrewmateByIdAsync(int id);
        Task AddCrewmateAsync(CrewmateCreateDTO crewmateDTO);
        Task UpdateCrewmateAsync(int id, CrewmateUpdateDTO crewmateDTO);
        Task DeleteCrewmateByIdAsync(int id);
    }
}
using CinemaApp.BL.DTOs.CrewDTOs;
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
        Task AddCrewmateAsync(CrewmateDTO crewmateDTO);
        Task UpdateCrewmateAsync(int id, CrewmateDTO crewmateDTO);
        Task DeleteCrewmateByIdAsync(int id);
    }
}

using CinemaApp.BL.DTOs.CrewDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface ICrewmatePositionsService
    {
        Task<IEnumerable<CrewmatePositionsDTO>> GetAllCrewmatePositionsAsync();
        Task<CrewmatePositionsDTO> GetCrewmatePositionsByIdAsync(int id);
        Task AddCrewmatePositionsAsync(CrewmatePositionsDTO crewmatePositionsDTO);
        Task UpdateCrewmatePositionsAsync(int id, CrewmatePositionsDTO crewmatePositionsDTO);
        Task DeleteCrewmatePositionsByIdAsync(int id);
    }
}

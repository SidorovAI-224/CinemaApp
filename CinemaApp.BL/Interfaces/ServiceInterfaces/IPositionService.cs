using CinemaApp.BL.DTOs.CrewDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface IPositionService
    {
        Task<IEnumerable<PositionDTO>> GetAllPositionsAsync();
        Task<PositionDTO> GetPositionByIdAsync(int id);
        Task AddPositionAsync(PositionDTO positionDTO);
        Task UpdatePositionAsync(int id, PositionDTO positionDTO);
        Task DeletePositionByIdAsync(int id);
    }
}

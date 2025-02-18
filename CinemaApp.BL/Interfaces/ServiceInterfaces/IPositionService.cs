using CinemaApp.BL.DTOs.CrewDTOs.Position;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface IPositionService
    {
        Task<IEnumerable<PositionDTO>> GetAllPositionsAsync();
        Task<PositionDTO> GetPositionByIdAsync(int id);
        Task AddPositionAsync(PositionCreateDTO positionCreateDTO);
        Task UpdatePositionAsync(int id, PositionUpdateDTO positionUpdateDTO);
        Task DeletePositionByIdAsync(int id);
    }
}
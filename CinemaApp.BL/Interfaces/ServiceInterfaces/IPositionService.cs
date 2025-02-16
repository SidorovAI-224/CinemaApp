using CinemaApp.BL.DTOs.CrewDTOs.Position;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface IPositionService
    {
        Task<IEnumerable<PositionDto>> GetAllPositionsAsync();
        Task<PositionDto> GetPositionByIdAsync(int id);
        Task AddPositionAsync(PositionCreateDto positionCreateDto);
        Task UpdatePositionAsync(int id, PositionUpdateDto positionUpdateDto);
        Task DeletePositionByIdAsync(int id);
    }
}
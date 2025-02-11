using CinemaApp.BL.DTOs.CrewDTOs.CrewmatePositions;

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
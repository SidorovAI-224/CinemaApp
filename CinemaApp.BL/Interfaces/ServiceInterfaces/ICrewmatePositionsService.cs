using CinemaApp.BL.DTOs.CrewDTOs.CrewmatePositions;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface ICrewmatePositionsService
    {
        Task<IEnumerable<CrewmatePositionsDto>> GetAllCrewmatePositionsAsync();
        Task<CrewmatePositionsDto> GetCrewmatePositionsByIdAsync(int id);
        Task AddCrewmatePositionsAsync(CrewmatePositionsDto crewmatePositionsDto);
        Task UpdateCrewmatePositionsAsync(int id, CrewmatePositionsDto crewmatePositionsDto);
        Task DeleteCrewmatePositionsByIdAsync(int id);
    }
}
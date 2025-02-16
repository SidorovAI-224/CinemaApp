using CinemaApp.BL.DTOs.CrewDTOs.Crewmate;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface ICrewmateService
    {
        Task<IEnumerable<CrewmateDto>> GetAllCrewmatesAsync();
        Task<CrewmateDto> GetCrewmateByIdAsync(int id);
        Task AddCrewmateAsync(CrewmateCreateDto crewmateDto);
        Task UpdateCrewmateAsync(int id, CrewmateUpdateDto crewmateDto);
        Task DeleteCrewmateByIdAsync(int id);
    }
}
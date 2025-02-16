using CinemaApp.BL.DTOs.CrewDTOs.Crewmate;

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
using CinemaApp.BL.DTOs.UserDTOs.Ticket;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDto>> GetAllTicketsAsync();
        Task<TicketDto> GetTicketByIdAsync(int id);
        Task AddTicketAsync(TicketCreateDto ticketCreateDto);
        Task UpdateTicketAsync(int id, TicketUpdateDto ticketUpdateDto);
        Task DeleteTicketByIdAsync(int id);
    }
}
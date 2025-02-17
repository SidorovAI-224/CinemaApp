using CinemaApp.BL.DTOs.UserDTOs.Ticket;
using CinemaApp.DAL.Entities;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDTO>> GetAllTicketsAsync();
        Task<TicketDTO> GetTicketByIdAsync(int id);
        Task AddTicketAsync(TicketCreateDTO ticketCreateDTO);
        Task UpdateTicketAsync(int id, TicketUpdateDTO ticketUpdateDTO);
        Task DeleteTicketByIdAsync(int id);
        Task AddTicketAsync(Ticket ticket);
        Task<IEnumerable<TicketDTO>> GetTicketsByUserIdAsync(string userId);
    }
}
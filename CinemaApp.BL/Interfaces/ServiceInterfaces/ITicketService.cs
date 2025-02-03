using CinemaApp.BL.DTOs.UserDTOs.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDTO>> GetAllTicketsAsync();
        Task<TicketDTO> GetTicketByIdAsync(int id);
        Task AddTicketAsync(TicketCreateDTO ticketCreateDTO);
        Task UpdateTicketAsync(int id, TicketUpdateDTO ticketUpdateDTO);
        Task DeleteTicketByIdAsync(int id);
    }
}

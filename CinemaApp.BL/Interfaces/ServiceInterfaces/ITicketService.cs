using CinemaApp.BL.DTOs.UserDTOs;
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
        Task AddTicketAsync(TicketDTO ticketDTO);
        Task UpdateTicketAsync(int id, TicketDTO ticketDTO);
        Task DeleteTicketByIdAsync(int id);
    }
}

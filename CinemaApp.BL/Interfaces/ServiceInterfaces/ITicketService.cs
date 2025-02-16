﻿using CinemaApp.BL.DTOs.UserDTOs.Ticket;

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
using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Services
{
    public class TicketService
    {


        private readonly IRepository<Ticket> _ticketRepository;
        
        public TicketService(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _ticketRepository.GetAllAsync();
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            return await _ticketRepository.GetByIdAsync(id);
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            await _ticketRepository.AddAsync(ticket);
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            await _ticketRepository.UpdateAsync(ticket);
        }

        public async Task DeleteTicketByIdAsync(int id)
        {
            await _ticketRepository.DeleteByIdAsync(id);
        }
    }

}

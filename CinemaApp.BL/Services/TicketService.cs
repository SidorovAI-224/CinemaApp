using AutoMapper;
using CinemaApp.BL.DTOs.UserDTOs.Ticket;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.DAL.Data;
using CinemaApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.BL.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IMapper _mapper;
        private readonly CinemaDbContext _context;

        public TicketService(IRepository<Ticket> ticketRepository, IMapper mapper, CinemaDbContext dbContext)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _context = dbContext;
        }

        public async Task<IEnumerable<TicketDTO>> GetAllTicketsAsync()
        {
            var tickets = await _context.Tickets
                .Include(t => t.Session)
                .Include(t => t.User)
                .ToListAsync();
            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);
        }

        public async Task<TicketDTO> GetTicketByIdAsync(int id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            return _mapper.Map<TicketDTO>(ticket);
        }

        public async Task AddTicketAsync(TicketCreateDTO ticketCreateDTO)
        {
            var ticket = _mapper.Map<Ticket>(ticketCreateDTO);
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTicketAsync(int id, TicketUpdateDTO ticketUpdateDTO)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            _mapper.Map(ticketUpdateDTO, ticket);
            await _ticketRepository.UpdateAsync(ticket);
        }

        public async Task DeleteTicketByIdAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            await _ticketRepository.AddAsync(ticket);
        }

        public async Task<IEnumerable<TicketDTO>> GetTicketsByUserIdAsync(string userId)
        {
            var tickets = await _context.Tickets
                .Include(t => t.Session)
                    .ThenInclude(s => s.Movie)
                .Where(t => t.UserID == userId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);
        }
    }
}

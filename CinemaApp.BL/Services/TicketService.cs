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
            // Перевірка існування SessionID
            var sessionExists = await _context.Sessions.AnyAsync(s => s.SessionID == ticketCreateDTO.SessionID);
            if (!sessionExists)
            {
                Console.WriteLine("Invalid SessionID.");
            }

            // Перевірка існування UserID
            var userExists = await _context.Users.AnyAsync(u => u.Id == ticketCreateDTO.UserID);
            if (!userExists)
            {
                Console.WriteLine("Invalid UserID.");
            }

            // Перевірка існування SeatID та RowID у HallOne
            var seatExists = await _context.HallOne.AnyAsync(h => h.SeatID == ticketCreateDTO.SeatID);
            if (!seatExists)
            {
                Console.WriteLine("Invalid SeatID.");
            }
            var rowExists = await _context.HallOne.AnyAsync(h => h.RowID == ticketCreateDTO.RowID);
            if (!rowExists)
            {
                Console.WriteLine("Invalid RowID.");
            }

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
            await _ticketRepository.DeleteByIdAsync(id);
        }
        public async Task AddTicketAsync(Ticket ticket) // Take the Entity directly // другий адд тікет а ми який юзаємо то
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

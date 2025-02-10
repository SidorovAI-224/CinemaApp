using AutoMapper;
using CinemaApp.BL.DTOs.UserDTOs.Ticket;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.DAL.Entities;

namespace CinemaApp.BL.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IMapper _mapper;

        public TicketService(IRepository<Ticket> ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TicketDTO>> GetAllTicketsAsync()
        {
            var tickets = await _ticketRepository.GetAllAsync();
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
            await _ticketRepository.AddAsync(ticket);
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
    }

}

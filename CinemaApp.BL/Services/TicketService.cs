using AutoMapper;
using CinemaApp.BL.DTOs.UserDTOs.Ticket;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Repositories;

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

        public async Task<IEnumerable<TicketDto>> GetAllTicketsAsync()
        {
            var tickets = await _ticketRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }

        public async Task<TicketDto> GetTicketByIdAsync(int id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            return _mapper.Map<TicketDto>(ticket);
        }

        public async Task AddTicketAsync(TicketCreateDto ticketCreateDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketCreateDto);
            await _ticketRepository.AddAsync(ticket);
        }

        public async Task UpdateTicketAsync(int id, TicketUpdateDto ticketUpdateDto)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            _mapper.Map(ticketUpdateDto, ticket);
            await _ticketRepository.UpdateAsync(ticket);
        }

        public async Task DeleteTicketByIdAsync(int id)
        {
            await _ticketRepository.DeleteByIdAsync(id);
        }
    }

}

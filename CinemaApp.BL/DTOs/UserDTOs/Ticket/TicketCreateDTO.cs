
namespace CinemaApp.BL.DTOs.UserDTOs.Ticket
{
    public abstract class TicketCreateDto
    {
        public int SessionId { get; set; }
        public string? UserId { get; set; }
        public int Seat { get; set; }
        public decimal Price { get; set; }
    }
}


namespace CinemaApp.BL.DTOs.UserDTOs.Ticket
{
    public class TicketUpdateDto
    {
        public int TicketId { get; set; }
        public int SessionId { get; set; }
        public int Seat { get; set; }
        public decimal Price { get; set; }
        public string? MovieTitle { get; set; }
        public DateTime SessionStartTime { get; set; }
    }
}

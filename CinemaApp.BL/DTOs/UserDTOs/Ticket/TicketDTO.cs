
namespace CinemaApp.BL.DTOs.UserDTOs.Ticket
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public int Seat { get; set; }
        public int SessionId { get; set; }
        public decimal Price { get; set; }
        public DateTime BookingDate { get; set; }
        public string? UserName { get; set; }
        public string? MovieTitle { get; set; }
        public DateTime SessionStartTime { get; set; }
    }
}

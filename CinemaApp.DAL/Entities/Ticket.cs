
namespace CinemaApp.DAL.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int SessionId { get; set; }
        public string? UserId { get; set; }
        public int? Seat { get; set; }

        public int Row { get; set; }
        public decimal? Price { get; set; }
        public DateTime? BookingDate { get; set; }
        public Session? Session { get; set; }
        public User? User { get; set; }
    }
}

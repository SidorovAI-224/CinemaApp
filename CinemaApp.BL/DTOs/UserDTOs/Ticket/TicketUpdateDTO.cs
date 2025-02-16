
namespace CinemaApp.BL.DTOs.UserDTOs.Ticket
{
    public class TicketUpdateDTO
    {
        public int TicketID { get; set; }
        public int SessionID { get; set; }
        public int Seat { get; set; }
        public decimal Price { get; set; }
        public string MovieTitle { get; set; }
        public DateTime SessionStartTime { get; set; }
    }
}

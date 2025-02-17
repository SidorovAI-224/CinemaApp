
namespace CinemaApp.BL.DTOs.UserDTOs.Ticket
{
    public class TicketUpdateDTO
    {
        public int TicketID { get; set; }
        public int SessionID { get; set; }
        public int SeatID { get; set; }
        public int RowID { get; set; }
        public decimal Price { get; set; } 
        public DateTime SessionStartTime { get; set; }
    }
}

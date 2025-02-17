
namespace CinemaApp.BL.DTOs.UserDTOs.Ticket
{
    public class TicketCreateDTO
    {
        public int SessionID { get; set; }
        public string UserID { get; set; }
        public int RowID { get; set; }
        public int SeatID { get; set; } 
        public decimal Price { get; set; }
        public DateTime BookingDate { get; set; }
    }
}

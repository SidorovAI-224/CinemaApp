using System.Collections.Generic;

namespace CinemaApp.DAL.Entities
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int SessionID { get; set; }
        public string UserID { get; set; }
        public int? SeatID { get; set; } // Зовнішній ключ для SeatID
        public int? RowID { get; set; }  // Зовнішній ключ для RowID
        public decimal Price { get; set; }
        public DateTime BookingDate { get; set; }
        public Session Session { get; set; }
        public User User { get; set; }
        public HallOne HallOne { get; set; }
    }
}

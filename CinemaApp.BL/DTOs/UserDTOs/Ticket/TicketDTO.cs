﻿
namespace CinemaApp.BL.DTOs.UserDTOs.Ticket
{
    public class TicketDTO
    {
        public int TicketID { get; set; }
        public int RowID {  get; set; }
        public int SeatID { get; set; }
        public int SessionID { get; set; }
        public decimal Price { get; set; }
        public DateTime BookingDate { get; set; }
        public string UserName { get; set; }
        public string MovieTitle { get; set; }
        public DateTime SessionStartTime { get; set; }
        public string Hall { get; set; }
        public string UserID { get; set; }
    }
}

﻿
namespace CinemaApp.BL.DTOs.UserDTOs.Ticket
{
    public class TicketCreateDTO
    {
        public int TicketID { get; set; }
        public int SessionID { get; set; }
        public string UserID { get; set; }
        public int Seat { get; set; }
        public decimal Price { get; set; }
    }
}

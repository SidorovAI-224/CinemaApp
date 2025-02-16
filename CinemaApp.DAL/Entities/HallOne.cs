﻿
namespace CinemaApp.DAL.Entities
{
    public class HallOne
    {
        public int SeatId { get; set; }
        public bool IsBooked { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}

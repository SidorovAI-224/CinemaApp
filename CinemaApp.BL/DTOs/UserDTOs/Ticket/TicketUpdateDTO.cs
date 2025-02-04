using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.DTOs.UserDTOs.Ticket
{
    public class TicketUpdateDTO
    {
        public int TicketID { get; set; }
        public int SessionID { get; set; }
        public int Seat { get; set; }
        public decimal Price { get; set; }
        //public string UserID { get; set; }
        public string MovieTitle { get; set; }
        public DateTime SessionStartTime { get; set; }
    }
}

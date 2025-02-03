using CinemaApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.DTOs.UserDTOs.Ticket
{
    public class TicketCreateDTO
    {
        public int SessionID { get; set; }
        public string UserID { get; set; }
        public int Seat { get; set; }
        public decimal Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DAL.Entities
{
    public class HallOne
    {
        public int SeatID { get; set; }
        public bool IsBooked { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}

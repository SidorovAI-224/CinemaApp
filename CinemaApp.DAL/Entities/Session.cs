using System.Collections.Generic;

namespace CinemaApp.DAL.Entities
{
    public class Session
    {
        public int SessionID { get; set; }
        public int MovieID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Date { get; set; }
        public string Hall { get; set; }

        public Movie Movie { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}

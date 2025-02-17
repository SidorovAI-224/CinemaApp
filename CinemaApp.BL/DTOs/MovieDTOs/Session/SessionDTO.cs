
using CinemaApp.DAL.Entities;

namespace CinemaApp.BL.DTOs.MovieDTOs.Session
{
    public class SessionDTO
    {
        public int SessionID { get; set; }
        public int MovieID { get; set; }
        public string MovieTitle { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Date { get; set; }
        public string Hall { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}

namespace CinemaApp.DAL.Entities
{
    public class HallOne
    {
        public int SeatID { get; set; }
        public int RowID { get; set; }
        public bool IsBooked { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}

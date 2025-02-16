
namespace CinemaApp.DAL.Entities
{
    public class MovieCrewmate
    {
        public int MovieId { get; set; }
        public int CrewmateId { get; set; }

        public int PositionId { get; set; }

        public Movie? Movie { get; set; }
        public Crewmate? Crewmate { get; set; }
        public Position? Position { get; set; }
    }
}

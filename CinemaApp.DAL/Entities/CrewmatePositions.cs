
namespace CinemaApp.DAL.Entities
{
    public class CrewmatePositions
    {
        public int CrewmateId { get; set; }
        public int PositionId { get; set; }


        public Crewmate? Crewmate { get; set; }
        public Position? Position { get; set; }
    }
}

namespace CinemaApp.DAL.Entities
{
    public class Position
    {
        public int PositionId { get; set; }
        public string? PositionName { get; set; }

        public ICollection<CrewmatePositions>? CrewmatePositions { get; set; }
    }
}

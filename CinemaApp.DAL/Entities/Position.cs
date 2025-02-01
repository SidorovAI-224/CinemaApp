using System.Collections.Generic;

namespace CinemaApp.DAL.Entities
{
    public class Position
    {
        public int PositionID { get; set; }
        public string PositionName { get; set; }

        public ICollection<CrewmatePositions>? CrewmatePositions { get; set; }
    }
}

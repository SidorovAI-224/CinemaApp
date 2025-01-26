using System.Collections.Generic;

namespace CinemaApp.DAL.Entities
{
    public class Position
    {
        public int PositionID { get; set; }
        public string PositionName { get; set; }

        public ICollection<Crewmate_Positions> CrewmatePositions { get; set; }
    }
}

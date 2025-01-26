using System.Collections.Generic;

namespace CinemaApp.DAL.Entities
{
    public class Crewmate_Positions
    {
        public int CrewmateID { get; set; }
        public int PositionID { get; set; }

        public Crewmate Crewmate { get; set; }
        public Position Position { get; set; }
    }
}

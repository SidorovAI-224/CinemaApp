using System.Collections.Generic;

namespace CinemaApp.DAL.Entities
{
    public class Crewmate
    {
        public int CrewmateID { get; set; }
        public string Name { get; set; }

        public ICollection<Movies_Crewmates> MoviesCrewmates { get; set; }
        public ICollection<Crewmate_Positions> CrewmatePositions { get; set; }
    }
}

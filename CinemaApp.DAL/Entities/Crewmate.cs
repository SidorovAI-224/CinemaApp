using System.Collections.Generic;

namespace CinemaApp.DAL.Entities
{
    public class Crewmate
    {
        public int CrewmateID { get; set; }
        public string Name { get; set; }

        public ICollection<MovieCrewmate> MoviesCrewmates { get; set; }
        public ICollection<CrewmatePositions> CrewmatePositions { get; set; }
    }
}

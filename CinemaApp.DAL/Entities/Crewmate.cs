using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.DAL.Entities
{
    public class Crewmate
    {
        public int CrewmateID { get; set; }
        public string Name { get; set; }
        public ICollection<MoviesCrewmates>? MoviesCrewmates { get; set; }
        public ICollection<CrewmatePositions>? CrewmatePositions { get; set; }
    }
}

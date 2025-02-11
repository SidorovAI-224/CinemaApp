
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates
{
    public class MovieCrewmateDTO
    {
        public int MovieID { get; set; }
        public int CrewmateID { get; set; }
        public int PositionID { get; set; }

        public string CrewmateName { get; set; } 
        public string PositionName { get; set; } 
    }
}

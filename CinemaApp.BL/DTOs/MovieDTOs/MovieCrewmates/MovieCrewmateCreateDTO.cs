using System.ComponentModel.DataAnnotations;

namespace CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates
{
    public class MovieCrewmateCreateDTO
    {
        public int MovieID { get; set; }
        public int CrewmateID { get; set; }
        public int PositionID { get; set; }
    }
}

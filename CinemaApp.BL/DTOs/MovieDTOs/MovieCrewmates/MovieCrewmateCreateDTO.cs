using System.ComponentModel.DataAnnotations;

namespace CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates
{
    public class MovieCrewmateCreateDTO
    {
        public int CrewmateID { get; set; }
        public int PositionID { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates
{
    public class MovieCrewmateCreateDTO
    {
        [Required(ErrorMessage = "Actor ID is required")]
        public int ActorID { get; set; }

        [Required(ErrorMessage = "Position is required")]
        [StringLength(100, ErrorMessage = "Position can't be longer than 100 characters")]
        public string Position { get; set; }
    }
}

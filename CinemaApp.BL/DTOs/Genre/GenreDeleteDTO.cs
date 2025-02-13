using System.ComponentModel.DataAnnotations;

namespace CinemaApp.BL.DTOs.MovieDTOs.Genre
{
    public class GenreDeleteDTO
    {
        [Required(ErrorMessage = "Genre ID is required")]
        public int GenreID { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CinemaApp.BL.DTOs.MovieDTOs.Genre
{
    public class GenreDeleteDto
    {
        [Required(ErrorMessage = "Genre ID is required")]
        public int GenreId { get; set; }
    }
}

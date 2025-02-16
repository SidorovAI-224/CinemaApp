using System.ComponentModel.DataAnnotations;

namespace CinemaApp.BL.DTOs.MovieDTOs.Genre
{
    public class GenreUpdateDto
    {
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Genre name is required")]
        public string? GenreName { get; set; }

    }
}

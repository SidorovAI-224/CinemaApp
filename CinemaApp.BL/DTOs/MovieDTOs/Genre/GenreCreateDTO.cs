using System.ComponentModel.DataAnnotations;


namespace CinemaApp.BL.DTOs.MovieDTOs.Genre
{
    public class GenreCreateDto
    {
        [Required(ErrorMessage = "Genre name is required")]
        public string? GenreName { get; set; }
    }
}

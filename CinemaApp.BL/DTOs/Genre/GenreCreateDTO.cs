using System.ComponentModel.DataAnnotations;


namespace CinemaApp.BL.DTOs.MovieDTOs.Genre
{
    public class GenreCreateDTO
    {
        [Required(ErrorMessage = "Genre name is required")]
        public string GenreName { get; set; }
    }
}

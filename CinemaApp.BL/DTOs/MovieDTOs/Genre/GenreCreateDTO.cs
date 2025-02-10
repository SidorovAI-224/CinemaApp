using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CinemaApp.BL.DTOs.MovieDTOs.Genre
{
    public class GenreCreateDTO
    {
        [Required(ErrorMessage = "Genre name is required")]
        public string GenreName { get; set; }
    }
}

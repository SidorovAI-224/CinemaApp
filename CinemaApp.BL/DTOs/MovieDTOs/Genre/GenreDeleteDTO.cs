using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.DTOs.MovieDTOs.Genre
{
    public class GenreDeleteDTO
    {
        [Required(ErrorMessage = "Genre ID is required")]
        public int GenreID { get; set; }
    }
}

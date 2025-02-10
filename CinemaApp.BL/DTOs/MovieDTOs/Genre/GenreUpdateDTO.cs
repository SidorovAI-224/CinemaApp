using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.BL.DTOs.MovieDTOs.Genre
{
    public class GenreUpdateDTO
    {
        public int GenreID { get; set; }

        [Required(ErrorMessage = "Genre name is required")]
        public string GenreName { get; set; }

    }
}

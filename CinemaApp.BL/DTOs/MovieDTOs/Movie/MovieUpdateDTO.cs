using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.DTOs.MovieDTOs.Movie
{
    public class MovieUpdateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterURL { get; set; }
        public string TrailerURL { get; set; }
        public decimal Rating { get; set; }
        public string AgeLimit { get; set; }
    }
}

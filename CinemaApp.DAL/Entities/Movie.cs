using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DAL.Entities
{
    public class Movie
    {

        public int movieId { get; set; }

        public string? title { get; set; } // ?null

        public string? description { get; set; } // ?null

        public int genreId { get; set; }

        public double duration { get; set; } 

        public DateTime releaseDate { get; set; }

        public string? PosterURL { get; set; } // ?null

        public string? TrailerURL { get; set; } // ?null

        public double rating { get; set; }

        public int ageLimit { get; set; }

    }
}

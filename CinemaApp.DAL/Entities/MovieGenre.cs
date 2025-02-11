using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DAL.Entities
{
    public class MovieGenre
    {
        public int MovieID { get; set; }
        public int GenreID { get; set; }

        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}

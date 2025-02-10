﻿//using System.Collections.Generic;

//namespace CinemaApp.DAL.Entities
//{
//    public class Genre
//    {
//        public int GenreID { get; set; }
//        public string GenreName { get; set; }

//        public ICollection<Movie> Movies { get; set; }
//    }
//}
using System.Collections.Generic;

namespace CinemaApp.DAL.Entities
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}


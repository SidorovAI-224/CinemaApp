﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.DTOs.MovieDTOs.MovieGenre
{
    public class MovieGenreDTO
    {
        public int MovieID { get; set; }
        public int GenreID { get; set; }
        public string? GenreName { get; set; }
    }
}

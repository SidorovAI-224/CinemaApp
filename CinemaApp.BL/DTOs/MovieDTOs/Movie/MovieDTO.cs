using CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates;
using System;
using System.Collections.Generic;

namespace CinemaApp.BL.DTOs.MovieDTOs.Movie
{
    public class MovieDTO
    {
        public int MovieID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? PosterURL { get; set; }
        public string? TrailerURL { get; set; } = "https://www.youtube.com/watch?v=dQw4w9WgXcQ&t=1s";
        public string Rating { get; set; } // decimal
        public int AgeLimit { get; set; }

        //unbeliveable genres
        // wall of shame
        public int GenreID { get; set; }
        public string? GenreName { get; set; }
        public int? GenreID1 { get; set; }
        public string? GenreName1 { get; set; }
        public int? GenreID2 { get; set; }
        public string? GenreName2 { get; set; }
        public int? GenreID3 { get; set; }
        public string? GenreName3 { get; set; }
        public int? GenreID4 { get; set; }
        public string? GenreName4 { get; set; }
        public List<MovieCrewmateDTO> MovieCrewmates { get; set; } = new List<MovieCrewmateDTO>();
    }
}
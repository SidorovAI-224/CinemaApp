using System;

namespace CinemaApp.BL.DTOs.MovieDTOs.Movie
{
    public class MovieDTO
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterURL { get; set; }
        public string TrailerURL { get; set; }
        public decimal Rating { get; set; }
        public int AgeLimit { get; set; }
    }
}

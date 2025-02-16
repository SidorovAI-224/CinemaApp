using CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates;

namespace CinemaApp.BL.DTOs.MovieDTOs.Movie
{
    public class MovieDto
    {
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? PosterUrl { get; set; }
        public string? TrailerUrl { get; set; }
        public decimal Rating { get; set; }
        public int AgeLimit { get; set; }

        //unbeliveable genres
        // wall of shame
        public int GenreId { get; set; }
        public string? GenreName { get; set; }
        public int? GenreId1 { get; set; }
        public string? GenreName1 { get; set; }
        public int? GenreId2 { get; set; }
        public string? GenreName2 { get; set; }
        public int? GenreId3 { get; set; }
        public string? GenreName3 { get; set; }
        public int? GenreId4 { get; set; }
        public string? GenreName4 { get; set; }
        public List<MovieCrewmateDTO> MovieCrewmates { get; set; } = new List<MovieCrewmateDTO>();
    }
}
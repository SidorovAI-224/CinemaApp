using System.Collections.Generic;

namespace CinemaApp.DAL.Entities
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int GenreID { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterURL { get; set; }
        public string TrailerURL { get; set; }
        public decimal Rating { get; set; }
        public string AgeLimit { get; set; }
        
        public Genre Genre { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<Movies_Crewmates> MoviesCrewmates { get; set; }
    }
}

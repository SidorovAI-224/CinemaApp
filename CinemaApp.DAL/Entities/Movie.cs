
namespace CinemaApp.DAL.Entities
{
    public class Movie
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


        //dumbass genres 
        public int GenreID { get; set; }
        public int? GenreID1 { get; set; }
        public int? GenreID2 { get; set; }
        public int? GenreID3 { get; set; }
        public int? GenreID4 { get; set; }

        public Genre Genre { get; set; }
        public Genre? Genre1 { get; set; }
        public Genre? Genre2 { get; set; }
        public Genre? Genre3 { get; set; }
        public Genre? Genre4 { get; set; }

        public ICollection<Session> Sessions { get; set; }
        public ICollection<MovieCrewmate> MovieCrewmates { get; set; }

    }
}


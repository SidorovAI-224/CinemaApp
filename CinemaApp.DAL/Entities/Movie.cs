
namespace CinemaApp.DAL.Entities
{
    public class Movie
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


        //dumbass genres 
        public int GenreId { get; set; }
        public int? GenreId1 { get; set; }
        public int? GenreId2 { get; set; }
        public int? GenreId3 { get; set; }
        public int? GenreId4 { get; set; }

        public Genre Genre { get; set; }
        public Genre? Genre1 { get; set; }
        public Genre? Genre2 { get; set; }
        public Genre? Genre3 { get; set; }
        public Genre? Genre4 { get; set; }

        public ICollection<Session> Sessions { get; set; }
        public ICollection<MovieCrewmate> MovieCrewmates { get; set; }

    }
}


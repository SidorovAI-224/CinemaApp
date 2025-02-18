using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CinemaApp.DAL.Entities;

namespace CinemaApp.BL.Services
{
    public class OMDbService
    {

        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly Random _random;

        public OMDbService(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
            _random = new Random();
        }

        private string GenerateRandomImdbId()
        {
            return $"tt{_random.Next(1000000, 10000000):0000000}";
        }

        public async Task<Movie> GetRandomMovieAsync()
        {
            try
            {
                string imdbId;
                OMDbMovieDetails movieDetails;

                for (int i = 0; i < 10; i++)
                {
                    imdbId = GenerateRandomImdbId();
                    var url = $"http://www.omdbapi.com/?i={imdbId}&apikey={_apiKey}";
                    movieDetails = await _httpClient.GetFromJsonAsync<OMDbMovieDetails>(url);

                    if (movieDetails?.Response == "True" && !string.IsNullOrEmpty(movieDetails.Title))
                    {
                        return new Movie
                        {
                            Title = movieDetails.Title,
                            Description = movieDetails.Plot,
                            Duration = TimeSpan.FromMinutes(movieDetails.Runtime != "N/A" && double.TryParse(movieDetails.Runtime.Split(' ')[0], out var runtime) ? runtime : 0),
                            ReleaseDate = DateTime.TryParse(movieDetails.Released, out var releaseDate) ? releaseDate : DateTime.MinValue,
                            PosterURL = movieDetails.Poster,
                            Rating = movieDetails.imdbRating != "N/A" ? movieDetails.imdbRating : "0.0",
                            AgeLimit = movieDetails.Rated.Contains("18") ? 18 : 12,
                            GenreID = 0 
                        };
                    }
                }

                Console.WriteLine("Failed to fetch a valid random movie after multiple attempts.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching a random movie: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Movie>> GetPopularMoviesAsync(int page = 1)
        {
            try
            {
                var url = $"http://www.omdbapi.com/?s=movie&page={page}&apikey={_apiKey}";
                var response = await _httpClient.GetFromJsonAsync<OMDbResponse>(url);

                if (response?.Search == null)
                {
                    Console.WriteLine("No movies found from OMDb API.");
                    return new List<Movie>();
                }

                var movies = new List<Movie>();
                foreach (var result in response.Search)
                {
                    var movieDetails = await GetMovieDetailsAsync(result.imdbID);
                    Console.WriteLine($"Fetched movie: {result.Title}");

                    var movie = new Movie
                    {
                        Title = result.Title,
                        Description = movieDetails.Plot,
                        Duration = TimeSpan.FromMinutes(movieDetails.Runtime != "N/A" && double.TryParse(movieDetails.Runtime.Split(' ')[0], out var runtime) ? runtime : 0),
                        ReleaseDate = DateTime.Parse(movieDetails.Released),
                        PosterURL = movieDetails.Poster,
                        Rating = movieDetails.imdbRating, 
                        AgeLimit = movieDetails.Rated.Contains("18") ? 18 : 12,
                        GenreID = 0 
                    };


                    movies.Add(movie);
                }

                return movies;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching movies: {ex.Message}");
                return new List<Movie>();
            }
        }


        private async Task<OMDbMovieDetails> GetMovieDetailsAsync(string imdbId)
        {
            var url = $"http://www.omdbapi.com/?i={imdbId}&apikey={_apiKey}";
            return await _httpClient.GetFromJsonAsync<OMDbMovieDetails>(url);
        }

        private class OMDbResponse
        {
            public List<OMDbMovie> Search { get; set; }
        }

        private class OMDbMovie
        {
            public string Title { get; set; }
            public string Year { get; set; }
            public string imdbID { get; set; }
            public string Type { get; set; }
            public string Poster { get; set; }
        }

        private class OMDbMovieDetails
        {
            public string Title { get; set; }
            public string Year { get; set; }
            public string Rated { get; set; }
            public string Released { get; set; }
            public string Runtime { get; set; }
            public string Genre { get; set; }
            public string Director { get; set; }
            public string Writer { get; set; }
            public string Actors { get; set; }
            public string Plot { get; set; }
            public string Language { get; set; }
            public string Country { get; set; }
            public string Awards { get; set; }
            public string Poster { get; set; }
            public string Metascore { get; set; }
            public string imdbRating { get; set; }
            public string imdbVotes { get; set; }
            public string imdbID { get; set; }
            public string Type { get; set; }
            public string DVD { get; set; }
            public string BoxOffice { get; set; }
            public string Production { get; set; }
            public string Website { get; set; }
            public string Response { get; set; }
        }
    }
}
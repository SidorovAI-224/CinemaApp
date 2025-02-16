using CinemaApp.BL.AI;
using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.Interfaces.ServiceInterfaces;


namespace CinemaApp.BL.Services
{
    public class AiService : IAIService
    {
        private readonly AiQueryRecommendations _queryRecommender;
        private readonly AiRecommendations _similarRecommender;
        private readonly IMovieService _movieService;

        public AiService(IConfiguration configuration, IMovieService movieService)
        {
            _movieService = movieService;

            Uri aiUri = new Uri(configuration["AI:BaseUrl"]);
            string model = configuration["AI:Model"];

            List<VectorizedMovie> movies = GetVectorizedMovies().Result;

            _queryRecommender = new AiQueryRecommendations(movies, aiUri, model);
            _similarRecommender = new AiRecommendations(movies, aiUri, model);
        }

        private async Task<List<VectorizedMovie>> GetVectorizedMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            List<VectorizedMovie> vectorizedMovies = new();

            foreach (var movie in movies)
            {
                vectorizedMovies.Add(new VectorizedMovie(movie));
            }

            return vectorizedMovies;
        }
        public async Task<List<VectorizedMovie>> GetRecommendedMovies (string query, uint maxResults)
        {
            return await _queryRecommender.GetRecommendationsByQuery(query, maxResults);
        }

        public async Task<List<VectorizedMovie>> GetSimilarMovies(int movieId, uint maxResults)
        {
            var movieDto = await _movieService.GetMovieByIdAsync(movieId);
            if (movieDto == null)
                return new List<VectorizedMovie>();

            var vectorizedMovie = new VectorizedMovie(movieDto);
            return await _similarRecommender.GetSimilarItems(vectorizedMovie, maxResults);
        }
    }
}

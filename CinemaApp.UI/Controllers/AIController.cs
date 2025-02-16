using CinemaApp.BL.AI;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using Microsoft.SemanticKernel.Services;
using IAIService = CinemaApp.BL.Interfaces.ServiceInterfaces.IAIService;

namespace CinemaApp.Controllers
{
    public class AiController : Controller
    {
        private readonly IAIService _aiService;

        public AiController(IAIService aiService)
        {
            _aiService = aiService;
        }

        public async Task<IActionResult> Recommendations(string query, uint maxResults = 5)
        {
            var recommendations = await _aiService.GetRecommendedMovies(query, maxResults);
            return View(recommendations);
        }

        public async Task<IActionResult> SimilarMovies(int movieId, uint maxResults = 5)
        {
            var similarMovies = await _aiService.GetSimilarMovies(movieId, maxResults);
            return View(similarMovies);
        }
    }
}

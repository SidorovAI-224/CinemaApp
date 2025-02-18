using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CinemaApp.BL.Interfaces.ServiceInterfaces;

namespace CinemaApp.Controllers
{
    [Route("api/ai")]
    [ApiController]
    public class AiController : ControllerBase
    {
        private readonly IAIService _aiService;

        public AiController(IAIService aiService)
        {
            _aiService = aiService;
        }

        [HttpGet("similar/{movieId}")]
        public async Task<IActionResult> GetSimilarMovies(int movieId, CancellationToken cancellationToken, [FromQuery] uint maxResults = 3)
        {
            var similarMovies = await _aiService.GetSimilarMovies(movieId, maxResults);

            Console.WriteLine(similarMovies.Count);

            if (similarMovies == null || similarMovies.Count == 0)
            {
                return StatusCode(202, new { message = "Рекомендации ещё не готовы" });
            }

            return Ok(similarMovies);
        }


        [HttpGet("recommendations")]
        public async Task<IActionResult> GetRecommendedMovies([FromQuery] string query, [FromQuery] uint maxResults = 2)
        {
            var recommendations = await _aiService.GetRecommendedMovies(query, maxResults);
            return Ok(recommendations);
        }
    }
}
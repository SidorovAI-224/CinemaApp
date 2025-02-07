using Microsoft.AspNetCore.Mvc;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.DTOs.MovieDTOs.Movie;

namespace CinemaApp.UI.Controllers
{
    [ApiController]
    [Route("Movie")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return View(movies);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] MovieCreateDTO movieDTO)
        {
            if (ModelState.IsValid)
            {
                await _movieService.AddMovieAsync(movieDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(movieDTO);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null) return NotFound();

            var movieUpdateDTO = new MovieUpdateDTO
            {
                Title = movie.Title,
                Description = movie.Description,
                GenreID = movie.GenreID,
                Duration = movie.Duration,
                ReleaseDate = movie.ReleaseDate,
                PosterURL = movie.PosterURL,
                TrailerURL = movie.TrailerURL,
                Rating = movie.Rating,
                AgeLimit = movie.AgeLimit
            };

            return View(movieUpdateDTO);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromForm] MovieUpdateDTO movieDTO)
        {
            if (ModelState.IsValid)
            {
                await _movieService.UpdateMovieAsync(id, movieDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(movieDTO);
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed([FromForm] int MovieID)
        {
            await _movieService.DeleteMovieByIdAsync(MovieID);
            return RedirectToAction(nameof(Index));
        }

    }
}

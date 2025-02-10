using Microsoft.AspNetCore.Mvc;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using System.Threading.Tasks;
using AutoMapper;

namespace CinemaApp.UI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieCreateDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(movieDTO);
            }

            try
            {
                await _movieService.AddMovieAsync(movieDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(movieDTO);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            var movieUpdateDTO = _mapper.Map<MovieUpdateDTO>(movie);
            return View(movieUpdateDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MovieUpdateDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(movieDTO);
            }

            try
            {
                await _movieService.UpdateMovieAsync(id, movieDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(movieDTO);
            }
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

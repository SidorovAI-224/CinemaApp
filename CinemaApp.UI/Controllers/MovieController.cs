using Microsoft.AspNetCore.Mvc;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return View(movies);
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed([FromForm] int MovieID)
        {
            await _movieService.DeleteMovieByIdAsync(MovieID);
            return RedirectToAction(nameof(Index));
        }
    }
}
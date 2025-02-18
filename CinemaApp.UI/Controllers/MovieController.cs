using Microsoft.AspNetCore.Mvc;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.BL.Services;

namespace CinemaApp.UI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICrewmateService _crewmateService;
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;
        private readonly IMovieCrewmateService _movieCrewmateService;
        private readonly IGenreService _genreService;
        public MovieController(
            IMovieService movieService,
            IMapper mapper,
            ICrewmateService crewmateService,
            IPositionService positionService,
            IMovieCrewmateService movieCrewmateService,
            IGenreService genreService)
        {
            _movieService = movieService;
            _mapper = mapper;
            _crewmateService = crewmateService;
            _positionService = positionService;
            _movieCrewmateService = movieCrewmateService;
            _genreService = genreService;
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
        public async Task<IActionResult> Create()
        {
            ViewBag.Genres = await _genreService.GetAllGenresAsync();
            var crewmates = await _crewmateService.GetAllCrewmatesAsync();
            var positions = await _positionService.GetAllPositionsAsync();

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(MovieCreateDTO movieCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                var crewmates = await _crewmateService.GetAllCrewmatesAsync();
                var positions = await _positionService.GetAllPositionsAsync();

                return View(movieCreateDTO);
            }

            try
            {
                await _movieService.AddMovieAsync(movieCreateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                var crewmates = await _crewmateService.GetAllCrewmatesAsync();
                var positions = await _positionService.GetAllPositionsAsync();
                return View(movieCreateDTO);
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

            ViewBag.Genres = await _genreService.GetAllGenresAsync();
            ViewBag.Crewmates = await _crewmateService.GetAllCrewmatesAsync();
            ViewBag.Positions = await _positionService.GetAllPositionsAsync();

            return View(movie);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Genres = await _genreService.GetAllGenresAsync();
                ViewBag.Crewmates = await _crewmateService.GetAllCrewmatesAsync();
                ViewBag.Positions = await _positionService.GetAllPositionsAsync();
                return View(movieDTO);
            }

            try
            {
                var movieUpdateDTO = _mapper.Map<MovieUpdateDTO>(movieDTO);
                await _movieService.UpdateMovieAsync(id, movieUpdateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                ViewBag.Genres = await _genreService.GetAllGenresAsync();
                ViewBag.Crewmates = await _crewmateService.GetAllCrewmatesAsync();
                ViewBag.Positions = await _positionService.GetAllPositionsAsync();
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

        [AllowAnonymous]
        [HttpGet("Movie/UserDetails/{id}")]
        public async Task<IActionResult> UserDetails(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }


        // [MOVIECREWMATE] Controllers - - - - -

        [Authorize(Roles = "Admin")]
        [HttpPost("AddCrewmateToMovie")]
        public async Task<IActionResult> AddCrewmateToMovie(int movieId, int crewmateId, int positionId)
        {
            await _movieCrewmateService.AddCrewmateToMovieAsync(movieId, crewmateId, positionId);
            return RedirectToAction(nameof(Edit), new { id = movieId });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("RemoveCrewmateFromMovie")]
        public async Task<IActionResult> RemoveCrewmateFromMovie(int movieId, int crewmateId)
        {
            await _movieCrewmateService.RemoveCrewmateFromMovieAsync(movieId, crewmateId);
            return RedirectToAction(nameof(Edit), new { id = movieId });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("UpdateCrewmateInMovie")]
        public async Task<IActionResult> UpdateCrewmateInMovie(int movieId, int crewmateId, int newCrewmateId, int newPositionId)
        {
            await _movieCrewmateService.UpdateCrewmateInMovieAsync(movieId, crewmateId, newCrewmateId, newPositionId);
            return RedirectToAction(nameof(Edit), new { id = movieId });
        }


        [HttpGet("Crewmate/GetCrewmateName")]
        public async Task<IActionResult> GetCrewmateName(int id)
        {
            var crewmate = await _crewmateService.GetCrewmateByIdAsync(id);
            if (crewmate == null)
            {
                return NotFound();
            }
            return Ok(new { name = crewmate.Name });
        }

        [HttpGet("Position/GetPositionName")]
        public async Task<IActionResult> GetPositionName(int id)
        {
            var position = await _positionService.GetPositionByIdAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            return Ok(new { name = position.PositionName });
        }
    }
}
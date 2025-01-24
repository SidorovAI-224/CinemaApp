using CinemaApp.BL.Services;
using CinemaApp.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinemaApp.UI.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieService _movieService;
        private readonly ILogger<MoviesController> _logger; // delete?

        public MoviesController(ILogger<MoviesController> logger) // delete?
        {
            _movieService = new MovieService();
            _logger = logger;
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _movieService.GetAll();
            return View(movies);
        }

        // POST: Movies/DeleteById
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteById(int movieId)
        {
            _movieService.Delete(movieId);
            return RedirectToAction("Index");
        }

        // POST: Movies/FindById
        [HttpPost]
        public ActionResult FindById(int movieId)
        {
            var movie = _movieService.GetById(movieId);
            if (movie == null)
            {
                return Json(new { success = false, message = "Movie not found" });
            }
            return Json(new { success = true, title = movie.title });
        }



        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.Create(movie);
                return RedirectToAction("Index");
            }
            return View("Index", _movieService.GetAll());
        }

        // GET: Movies/Edit/id
        public ActionResult Edit(int id)
        {
            var movie = _movieService.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.Update(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // POST: Movies/EditById/id
        [HttpPost]
        public ActionResult EditById(int movieId)
        {
            var movie = _movieService.GetById(movieId);
            if (movie == null)
            {
                return NotFound();
            }
            return RedirectToAction("Edit", new { id = movieId });
        }
    }
}

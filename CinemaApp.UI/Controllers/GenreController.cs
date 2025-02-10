//using Microsoft.AspNetCore.Mvc;
//using CinemaApp.BL.Interfaces;
//using System.Threading.Tasks;
//using CinemaApp.BL.DTOs.MovieDTOs.Genre;
//using CinemaApp.BL.Interfaces.ServiceInterfaces;

//namespace CinemaApp.UI.Controllers
//{
//    [Route("Genre")]
//    public class GenreController : Controller
//    {
//        private readonly IGenreService _genreService;

//        public GenreController(IGenreService genreService)
//        {
//            _genreService = genreService;
//        }

//        [HttpGet("Index")]
//        public async Task<IActionResult> Index()
//        {
//            var genres = await _genreService.GetAllGenresAsync();
//            return View(genres);
//        }

//        [HttpGet("Create")]
//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost("Create")]
//        public async Task<IActionResult> Create(GenreCreateDTO genreDTO)
//        {
//            if (ModelState.IsValid)
//            {
//                await _genreService.AddGenreAsync(genreDTO);
//                return RedirectToAction(nameof(Index));
//            }
//            return View(genreDTO);
//        }

//        [HttpGet("Edit/{id}")]
//        public async Task<IActionResult> Edit(int id)
//        {
//            var genre = await _genreService.GetGenreByIdAsync(id);
//            if (genre == null) return NotFound();

//            var genreUpdateDTO = new GenreUpdateDTO
//            {
//                GenreID = genre.GenreID,
//                GenreName = genre.GenreName
//            };

//            return View(genreUpdateDTO);
//        }

//        [HttpPost("Edit/{id}")]
//        public async Task<IActionResult> Edit(int id, GenreUpdateDTO genreUpdateDTO)
//        {
//            if (ModelState.IsValid)
//            {
//                await _genreService.UpdateGenreAsync(id, genreUpdateDTO);
//                return RedirectToAction(nameof(Index));
//            }
//            return View(genreUpdateDTO);
//        }

//        [HttpGet("Delete/{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var genre = await _genreService.GetGenreByIdAsync(id);
//            if (genre == null) return NotFound();
//            return View(genre);
//        }

//        [HttpPost("Delete/{id}")]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            await _genreService.DeleteGenreByIdAsync(id);
//            return RedirectToAction(nameof(Index));
//        }

//    }
//}
using Microsoft.AspNetCore.Mvc;
using CinemaApp.BL.Interfaces;
using System.Threading.Tasks;
using CinemaApp.BL.DTOs.MovieDTOs.Genre;
using CinemaApp.BL.Interfaces.ServiceInterfaces;

namespace CinemaApp.UI.Controllers
{
    [Route("Genre")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var genres = await _genreService.GetAllGenresAsync();
            return View(genres);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(GenreCreateDTO genreDTO)
        {
            if (ModelState.IsValid)
            {
                await _genreService.AddGenreAsync(genreDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(genreDTO);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre == null) return NotFound();

            var genreUpdateDTO = new GenreUpdateDTO
            {
                GenreID = genre.GenreID,
                GenreName = genre.GenreName
            };

            return View(genreUpdateDTO);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, GenreUpdateDTO genreUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                await _genreService.UpdateGenreAsync(id, genreUpdateDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(genreUpdateDTO);
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre == null) return NotFound();
            return View(genre);
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _genreService.DeleteGenreByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
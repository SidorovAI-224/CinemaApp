using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CinemaApp.UI.Models;
using CinemaApp.BL;
using Microsoft.AspNetCore.Authorization;
using CinemaApp.BL.Interfaces;

namespace CinemaApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly GreetingService _greetingService;
        private readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            // Ініціалізація GreetingService, але він не використовується в контролері. Можливо, ви хочете його додати до іншого методу.
            _greetingService = new GreetingService();
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            // Встановлюємо активну сторінку для головної сторінки
            ViewData["ActivePage"] = "Home"; 
            ViewData["PageClass"] = "home-page"; // Додаємо клас для фону головної сторінки

            var movies = await _movieService.GetAllMoviesAsync();
            return View(movies);
        }

        [Authorize]
        public IActionResult Privacy()
        {
            // Встановлюємо активну сторінку для сторінки Privacy
            ViewData["ActivePage"] = "Privacy"; 
            ViewData["PageClass"] = "privacy-page"; // Додаємо клас для фону сторінки Privacy

            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            // Встановлюємо активну сторінку для сторінки Admin
            ViewData["ActivePage"] = "Admin"; 
            ViewData["PageClass"] = "admin-page"; // Додаємо клас для фону сторінки Admin

            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult User()
        {
            // Встановлюємо активну сторінку для сторінки User
            ViewData["ActivePage"] = "User"; 
            ViewData["PageClass"] = "user-page"; // Додаємо клас для фону сторінки User

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Виводимо інформацію про помилки на сторінці Error
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

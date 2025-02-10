using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CinemaApp.UI.Models;
using CinemaApp.BL;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using CinemaApp.BL.Interfaces;
using System.Threading.Tasks;
namespace CinemaApp.UI.Controllers;

public class HomeController : Controller
{
    private readonly GreetingService _greetingService;
    private readonly IMovieService _movieService;

    public HomeController(IMovieService movieService)
    {
        _greetingService = new GreetingService();
        _movieService = movieService;
    }

    public async Task<IActionResult> Index()
    {
        var movies = await _movieService.GetAllMoviesAsync();
        return View(movies);
    }

    [Authorize]
    public IActionResult Privacy()
    {
        return View();
    }
    [Authorize(Roles = "Admin")]
    public IActionResult Admin()
    {
        return View();
    }
    [Authorize(Roles = "User")]
    public IActionResult User()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
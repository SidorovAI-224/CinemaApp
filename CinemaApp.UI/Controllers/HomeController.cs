using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CinemaApp.UI.Models;
using Microsoft.AspNetCore.Authorization;
using CinemaApp.BL.Interfaces;
namespace CinemaApp.UI.Controllers;

public class HomeController : Controller
{
    private readonly IMovieService _movieService;

    public HomeController(IMovieService movieService)
    {
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
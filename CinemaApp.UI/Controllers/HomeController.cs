using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CinemaApp.UI.Models;
using CinemaApp.BL;

namespace CinemaApp.UI.Controllers;

public class HomeController : Controller
{
    private readonly GreetingService _greetingService;

    public HomeController()
    {
        _greetingService = new GreetingService();
    }

    public IActionResult Index()
    {
        ViewData["Greeting"] = _greetingService.GetGreeting();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

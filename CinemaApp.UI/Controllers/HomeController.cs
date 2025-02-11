using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CinemaApp.UI.Models;
using CinemaApp.BL;
using Microsoft.AspNetCore.Authorization;

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

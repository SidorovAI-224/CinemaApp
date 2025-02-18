using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.UI.Controllers
{
    public class MoviesCrewmatesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

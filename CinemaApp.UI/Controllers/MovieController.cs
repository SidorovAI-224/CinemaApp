using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.UI.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

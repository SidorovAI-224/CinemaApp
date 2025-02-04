using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.UI.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

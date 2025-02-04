using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.UI.Controllers
{
    public class CrewmateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

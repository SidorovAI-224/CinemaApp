using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.UI.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

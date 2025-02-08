using CinemaApp.BL.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.UI.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}

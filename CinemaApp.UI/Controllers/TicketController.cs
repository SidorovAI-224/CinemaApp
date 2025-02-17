using AutoMapper;
using CinemaApp.BL.DTOs.UserDTOs.Ticket;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CinemaApp.UI.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public TicketController(ITicketService ticketService, ISessionService sessionService, IMapper mapper)
        {
            _ticketService = ticketService;
            _sessionService = sessionService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> TicketIndex()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return View(tickets);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> TicketCreateBooking(int sessionId)
        {
            var session = await _sessionService.GetSessionByIdAsync(sessionId);
            if (session == null)
            {
                return NotFound();
            }

            var tickets = await _ticketService.GetAllTicketsAsync();
            var takenSeats = tickets
                .Where(t => t.SessionID == sessionId)
                .Select(t => t.SeatID)
                .ToList();

            ViewBag.Session = session;
            ViewBag.TakenSeats = takenSeats;

            var model = new TicketCreateDTO
            {
                SessionID = sessionId,
                UserID = User.FindFirstValue(ClaimTypes.NameIdentifier),
                BookingDate = DateTime.Now,
                Price = 140.00m
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> TicketCreateBooking(string selectedSeats)
        {
            if (string.IsNullOrEmpty(selectedSeats))
            {
                return BadRequest("No seats selected");
            }

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var sessionId = int.Parse(Request.Form["SessionID"]);
                var seats = selectedSeats.Split(',');

                foreach (var seat in seats)
                {
                    var seatParts = seat.Split('-');
                    var row = int.Parse(seatParts[0]);
                    var seatNum = int.Parse(seatParts[1]);

                    var ticketCreateDTO = new TicketCreateDTO
                    {
                        SessionID = sessionId,
                        UserID = userId,
                        RowID = row,
                        SeatID = seatNum,
                        Price = 140.00m,
                        BookingDate = DateTime.Now
                    };

                    await _ticketService.AddTicketAsync(ticketCreateDTO);
                }

                TempData["SuccessMessage"] = "Tickets purchased successfully!";
                return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while processing your request." });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> TicketEdit(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            var model = new TicketUpdateDTO
            {
                TicketID = ticket.TicketID,
                SessionID = ticket.SessionID,
                SeatID = ticket.SeatID,
                RowID = ticket.RowID,
                Price = ticket.Price,
                SessionStartTime = ticket.SessionStartTime
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> TicketEdit(TicketUpdateDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _ticketService.UpdateTicketAsync(model.TicketID, model);
                return RedirectToAction("TicketIndex");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Помилка оновлення квитка");
                return View(model);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> TicketDelete(int id)
        {
            var ticketDTO = await _ticketService.GetTicketByIdAsync(id);
            if (ticketDTO == null)
            {
                return NotFound();
            }

            return View(ticketDTO);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> TicketDeleted(TicketDeleteDTO model)
        {
            try
            {
                await _ticketService.DeleteTicketByIdAsync(model.TicketID);
                return RedirectToAction("TicketIndex");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Помилка видалення квитка");
                return RedirectToAction("TicketDelete", new { id = model.TicketID });
            }
        }

    }
}

using AutoMapper;
using CinemaApp.BL.DTOs.UserDTOs.Ticket;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CinemaApp.UI.Controllers
{
    
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ISessionService _sessionService;

        public TicketController(ITicketService ticketService, ISessionService sessionService)
        {
            _ticketService = ticketService;
            _sessionService = sessionService;
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
                .Select(t => t.Seat)
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
                        Row = row,
                        Seat = seatNum,
                        Price = 140.00m,
                        BookingDate = DateTime.Now
                    };

                    await _ticketService.AddTicketAsync(ticketCreateDTO);
                }

                TempData["SuccessMessage"] = "Tickets purchased successfully!";
                return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
            }
            /*
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var sessionId = int.Parse(Request.Form["SessionID"]);
                var seats = selectedSeats.Split(',').Select(int.Parse).ToList();

                foreach (var seat in seats)
                {
                    var ticketCreateDTO = new TicketCreateDTO
                    {
                        SessionID = sessionId,
                        UserID = userId,
                        Seat = seat,
                        Price = 140.00m,
                        BookingDate = DateTime.Now
                    };

                    await _ticketService.AddTicketAsync(ticketCreateDTO);
                }

                TempData["SuccessMessage"] = "Tickets purchased successfully!";
                return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
            }
            */
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while processing your request." });
            }
        }

        // ДОДАНІ МЕТОДИ ДЛЯ РЕДАГУВАННЯ ТА ВИДАЛЕННЯ
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
                Seat = ticket.Seat,
                Price = ticket.Price,
                MovieTitle = ticket.MovieTitle,
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
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("TicketDelete")] // Додаємо ActionName, щоб маршрут був однаковий
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _ticketService.DeleteTicketByIdAsync(id);
                return RedirectToAction("TicketIndex");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Помилка видалення квитка");
                return RedirectToAction("Delete", new { id });
            }
        }
    }
}
    

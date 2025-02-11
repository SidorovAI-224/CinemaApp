using CinemaApp.BL.DTOs.UserDTOs.Ticket;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: Ticket
        public async Task<IActionResult> TicketIndex()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return View(tickets);
        }

        // GET: Ticket/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketCreateDTO ticketCreateDTO)
        {
            if (ModelState.IsValid)
            {
                await _ticketService.AddTicketAsync(ticketCreateDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(ticketCreateDTO);
        }

        // GET: Ticket/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            var ticketUpdateDTO = new TicketUpdateDTO
            {
                TicketID = ticket.TicketID,
                SessionID = ticket.SessionID,
                Seat = ticket.Seat,
                Price = ticket.Price,
                MovieTitle = ticket.MovieTitle,
                SessionStartTime = ticket.SessionStartTime
            };
            return View(ticketUpdateDTO);
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TicketUpdateDTO ticketUpdateDTO)
        {
            if (id != ticketUpdateDTO.TicketID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _ticketService.UpdateTicketAsync(id, ticketUpdateDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(ticketUpdateDTO);
        }

        // GET: Ticket/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ticketService.DeleteTicketByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

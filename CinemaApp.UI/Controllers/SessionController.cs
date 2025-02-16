using Microsoft.AspNetCore.Mvc;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.DTOs.MovieDTOs.Session;
using AutoMapper;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;

namespace CinemaApp.UI.Controllers
{
    public class SessionController : Controller
    {
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public SessionController(ISessionService sessionService, IMapper mapper)
        {
            _sessionService = sessionService;
            _mapper = mapper;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SessionIndex()
        {
            var sessions = await _sessionService.GetAllSessionsAsync();
            return View(sessions);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult SessionCreate()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> SessionCreate(SessionCreateDTO sessionCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(sessionCreateDTO);
            }

            try
            {
                var session = await _sessionService.AddSessionAsync(sessionCreateDTO);
                return RedirectToAction("SessionIndex");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Session adding error: " + ex.Message);
                return View(sessionCreateDTO);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> SessionEdit(int id)
        {
            var session = await _sessionService.GetSessionByIdAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            var sessionUpdateDTO = _mapper.Map<SessionUpdateDTO>(session);
            return View(sessionUpdateDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> SessionEdit(int id, SessionUpdateDTO sessionUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(sessionUpdateDTO);
            }

            try
            {
                if (id != sessionUpdateDTO.SessionID)
                {
                    return BadRequest();
                }
                await _sessionService.UpdateSessionAsync(id, sessionUpdateDTO);
                return RedirectToAction("SessionIndex");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Session update error: " + ex.Message);
                return View(sessionUpdateDTO);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> SessionDelete(int id)
        {
            var session = await _sessionService.GetSessionByIdAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            var sessionDTO = _mapper.Map<SessionDeleteDTO>(session);
            return View(sessionDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> SessionDeleteConfirmed(int id)
        {
            try
            {
                await _sessionService.DeleteSessionByIdAsync(id);
                return RedirectToAction("SessionIndex");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Session delete error: " + ex.Message);
                return View(await _sessionService.GetSessionByIdAsync(id));
            }
        }

        [HttpGet]
        public async Task<IActionResult> SessionUserIndex()
        {
            var sessions = await _sessionService.GetAllSessionsAsync();
            return View(sessions);
        }
    }
}
//using Microsoft.AspNetCore.Mvc;
//using CinemaApp.BL.Interfaces;
//using CinemaApp.BL.DTOs.MovieDTOs.Session;
//using System.Threading.Tasks;
//using AutoMapper;

//namespace CinemaApp.UI.Controllers
//{
//    public class SessionController : Controller
//    {
//        private readonly ISessionService _sessionService;
//        private readonly IMapper _mapper;

//        public SessionController(ISessionService sessionService, IMapper mapper)
//        {
//            _sessionService = sessionService;
//            _mapper = mapper;
//        }

//        public async Task<IActionResult> SessionIndex()
//        {
//            var sessions = await _sessionService.GetAllSessionsAsync();
//            return View(sessions);
//        }

//        [HttpGet]
//        public IActionResult SessionCreate()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> SessionCreate(SessionCreateDTO sessionCreateDTO)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(sessionCreateDTO);
//            }

//            try
//            {
//                var session = await _sessionService.AddSessionAsync(sessionCreateDTO);
//                return RedirectToAction("SessionIndex");
//            }
//            catch (Exception ex)
//            {
//                ModelState.AddModelError(string.Empty, "Помилка при додаванні сесії: " + ex.Message);
//                return View(sessionCreateDTO);
//            }
//        }

//        [HttpGet]
//        public async Task<IActionResult> SessionEdit(int id)
//        {
//            var session = await _sessionService.GetSessionByIdAsync(id);
//            if (session == null)
//            {
//                return NotFound();
//            }
//            var sessionUpdateDTO = _mapper.Map<SessionUpdateDTO>(session);
//            return View(sessionUpdateDTO);
//        }

//        [HttpPost]
//        public async Task<IActionResult> SessionEdit(int id, SessionUpdateDTO sessionUpdateDTO)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(sessionUpdateDTO);
//            }

//            try
//            {
//                if (id != sessionUpdateDTO.SessionID)
//                {
//                    return BadRequest();
//                }
//                await _sessionService.UpdateSessionAsync(id, sessionUpdateDTO);
//                return RedirectToAction("SessionIndex");
//            }
//            catch (Exception ex)
//            {
//                ModelState.AddModelError(string.Empty, "Помилка при оновленні сесії: " + ex.Message);
//                return View(sessionUpdateDTO);
//            }
//        }


//        [HttpGet]
//        public async Task<IActionResult> SessionDelete(int id)
//        {
//            var session = await _sessionService.GetSessionByIdAsync(id);
//            if (session == null)
//            {
//                return NotFound();
//            }
//            var sessionDTO = _mapper.Map<SessionDeleteDTO>(session);
//            return View(sessionDTO);
//        }

//        [HttpPost]
//        public async Task<IActionResult> SessionDeleteConfirmed(int id)
//        {
//            try
//            {
//                await _sessionService.DeleteSessionByIdAsync(id);
//                return RedirectToAction("SessionIndex");
//            }
//            catch (Exception ex)
//            {
//                ModelState.AddModelError(string.Empty, "Помилка при видаленні сесії: " + ex.Message);
//                return View(await _sessionService.GetSessionByIdAsync(id));
//            }
//        }

//        [HttpGet]
//        public async Task<IActionResult> SessionUserIndex()
//        {
//            var sessions = await _sessionService.GetAllSessionsAsync();
//            return View(sessions);
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.DTOs.MovieDTOs.Session;
using System.Threading.Tasks;
using AutoMapper;

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

        public async Task<IActionResult> SessionIndex()
        {
            var sessions = await _sessionService.GetAllSessionsAsync();
            return View(sessions);
        }

        [HttpGet]
        public IActionResult SessionCreate()
        {
            return View();
        }

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
                ModelState.AddModelError(string.Empty, "Помилка при додаванні сесії: " + ex.Message);
                return View(sessionCreateDTO);
            }
        }

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
                ModelState.AddModelError(string.Empty, "Помилка при оновленні сесії: " + ex.Message);
                return View(sessionUpdateDTO);
            }
        }


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
                ModelState.AddModelError(string.Empty, "Помилка при видаленні сесії: " + ex.Message);
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
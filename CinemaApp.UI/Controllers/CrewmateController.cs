using Microsoft.AspNetCore.Mvc;
using CinemaApp.BL.DTOs.CrewDTOs.Crewmate;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using System.Threading.Tasks;
using CinemaApp.BL.Services;
using Microsoft.AspNetCore.Authorization;

namespace CinemaApp.Web.Controllers
{
    public class CrewmateController : Controller
    {
        private readonly ICrewmateService _crewmateService;

        public CrewmateController(ICrewmateService crewmateService)
        {
            _crewmateService = crewmateService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> CrewmateAdminIndex()
        {
            var crewmates = await _crewmateService.GetAllCrewmatesAsync();
            return View(crewmates);
        }

        [Authorize(Roles = "Admin")] // ?
        [HttpGet]
        public async Task<IActionResult> CrewmateDetails(int id)
        {
            var crewmate = await _crewmateService.GetCrewmateByIdAsync(id);
            if (crewmate == null)
            {
                return NotFound();
            }
            return View(crewmate);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CrewmateCreate()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrewmateCreate(CrewmateCreateDTO crewmateCreateDTO)
        {
            if (ModelState.IsValid)
            {
                await _crewmateService.AddCrewmateAsync(crewmateCreateDTO);
                return RedirectToAction(nameof(CrewmateAdminIndex));
            }
            return View(crewmateCreateDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> CrewmateEdit(int id)
        {
            var crewmate = await _crewmateService.GetCrewmateByIdAsync(id);
            if (crewmate == null)
            {
                return NotFound();
            }
            var crewmateUpdateDTO = new CrewmateUpdateDTO
            {
                CrewmateID = crewmate.CrewmateID,
                Name = crewmate.Name,
            };
            return View(crewmateUpdateDTO);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrewmateEdit(int id, CrewmateUpdateDTO crewmateUpdateDTO)
        {
            if (id != crewmateUpdateDTO.CrewmateID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _crewmateService.UpdateCrewmateAsync(id, crewmateUpdateDTO);
                return RedirectToAction(nameof(CrewmateAdminIndex));
            }
            return View(crewmateUpdateDTO);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> CrewmateDelete(int id)
        {
            var crewmate = await _crewmateService.GetCrewmateByIdAsync(id);
            if (crewmate == null)
            {
                return NotFound();
            }
            return View(crewmate);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrewmateDeleteConfirmed(int id)
        {
            await _crewmateService.DeleteCrewmateByIdAsync(id);
            return RedirectToAction(nameof(CrewmateAdminIndex));
        }
    }
}
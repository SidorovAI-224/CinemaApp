using Microsoft.AspNetCore.Mvc;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.BL.DTOs.CrewDTOs.Position;
using Microsoft.AspNetCore.Authorization;

namespace CinemaApp.UI.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PositionAdminIndex()
        {
            var positions = await _positionService.GetAllPositionsAsync();
            return View(positions);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult PositionCreate()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PositionCreate(PositionCreateDto positionCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(positionCreateDTO);
            }

            await _positionService.AddPositionAsync(positionCreateDTO);
            return RedirectToAction(nameof(PositionAdminIndex));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> PositionEdit(int id)
        {
            var position = await _positionService.GetPositionByIdAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            var positionUpdateDTO = new PositionUpdateDto
            {
                PositionId = position.PositionId,
                PositionName = position.PositionName,
            };
            
            return View(positionUpdateDTO);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PositionEdit(int id, PositionUpdateDto positionUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(positionUpdateDTO);
            }

            await _positionService.UpdatePositionAsync(id, positionUpdateDTO);
            return RedirectToAction(nameof(PositionAdminIndex));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> PositionDelete(int id)
        {
            var position = await _positionService.GetPositionByIdAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _positionService.DeletePositionByIdAsync(id);
            return RedirectToAction(nameof(PositionAdminIndex));
        }

    }
}

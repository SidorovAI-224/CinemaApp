using Microsoft.AspNetCore.Mvc;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.BL.DTOs.CrewDTOs.Position;
using System.Threading.Tasks;

namespace CinemaApp.UI.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        public async Task<IActionResult> PositionAdminIndex()
        {
            var positions = await _positionService.GetAllPositionsAsync();
            return View(positions);
        }

        [HttpGet]
        public IActionResult PositionCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PositionCreate(PositionCreateDTO positionCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(positionCreateDTO);
            }

            await _positionService.AddPositionAsync(positionCreateDTO);
            return RedirectToAction(nameof(PositionAdminIndex));
        }

        [HttpGet]
        public async Task<IActionResult> PositionEdit(int id)
        {
            var position = await _positionService.GetPositionByIdAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            var positionUpdateDTO = new PositionUpdateDTO
            {
                PositionID = position.PositionID,
                PositionName = position.PositionName,
            };
            
            return View(positionUpdateDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PositionEdit(int id, PositionUpdateDTO positionUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(positionUpdateDTO);
            }

            await _positionService.UpdatePositionAsync(id, positionUpdateDTO);
            return RedirectToAction(nameof(PositionAdminIndex));
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _positionService.DeletePositionByIdAsync(id);
            return RedirectToAction(nameof(PositionAdminIndex));
        }

    }
}

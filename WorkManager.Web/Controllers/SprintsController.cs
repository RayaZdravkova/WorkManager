using Microsoft.AspNetCore.Mvc;
using WorkManager.Business.Services.Interfaces;
using WorkManager.Business.ViewModels.Sprint;

namespace WorkManager.Web.Controllers
{
    public class SprintsController : Controller
    {
        private readonly ISprintService _sprintService;

        public SprintsController(ISprintService sprintService)
        {
            _sprintService = sprintService;
        }

        public async Task<IActionResult> Index()
        {
            List<SprintViewModel> allSprints = await _sprintService.GetAllAsync();
            return View(allSprints);
        }

        public async Task<IActionResult> Details(int id)
        {
            SprintViewModel? sprint = await _sprintService.GetByIdAsync(id);
            if (sprint is null)
            {
                TempData["ValidationMessage"] = "Sprint not found!";
                return RedirectToAction("Index");
            }
            return View(sprint);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SprintCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ValidationMessage"] = "Invalid data!";
                return View(model);
            }

            try
            {
                await _sprintService.CreateAsync(model);
            }
            catch (ArgumentException ex)
            {
                TempData["ValidationMessage"] = ex.Message;
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            SprintViewModel? model = await _sprintService.GetByIdAsync(id);

            if (model is null)
            {
                TempData["ValidationMessage"] = "Sprint not found!";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SprintViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ValidationMessage"] = "Invalid data!";
                return View(model);
            }

            try
            {
                await _sprintService.UpdateAsync(model);
            }
            catch (ArgumentException ex)
            {
                TempData["ValidationMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            SprintViewModel? model = await _sprintService.GetByIdAsync(id);

            if (model is null)
            {
                TempData["ValidationMessage"] = "Sprint not found!";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            try
            {
                await _sprintService.DeleteAsync(id);
            }
            catch (ArgumentException ex)
            {
                TempData["ValidationMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}

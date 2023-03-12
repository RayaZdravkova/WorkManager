using Microsoft.AspNetCore.Mvc;
using WorkManager.Business.Services.Interfaces;
using WorkManager.Business.ViewModels.Employee;

namespace WorkManager.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            List<EmployeeViewModel> allEmployees = await _employeeService.GetAllAsync();
            return View(allEmployees);
        }

        public async Task<IActionResult> Details(int id)
        {
            EmployeeViewModel? employee = await _employeeService.GetByIdAsync(id);
            if (employee is null)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _employeeService.CreateAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            EmployeeViewModel? model = await _employeeService.GetByIdAsync(id);

            if (model is null) 
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _employeeService.UpdateAsync(model);
            }
            catch (ArgumentException)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            EmployeeViewModel? model = await _employeeService.GetByIdAsync(id);

            if (model is null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            try
            {
                await _employeeService.DeleteAsync(id);
            }
            catch (ArgumentException)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}

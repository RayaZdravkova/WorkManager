using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkManager.Business.Services.Interfaces;
using WorkManager.Business.ViewModels.Employee;
using WorkManager.Business.ViewModels.Task;
using WorkManager.Data.Enums;

namespace WorkManager.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public TasksController(ITaskService taskService, IEmployeeService employeeService, IMapper mapper)
        {
            _taskService = taskService;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<TaskViewModel> allTasks = await _taskService.GetAllAsync();
            return View(allTasks);
        }

        public async Task<IActionResult> Details(int id)
        {
            TaskViewModel? task = await _taskService.GetByIdAsync(id);

            if (task is null)
            {
                return RedirectToAction("Index");
            }

            TaskDetailsViewModel model = _mapper.Map<TaskDetailsViewModel>(task);
            EmployeeViewModel? assignee =await _employeeService.GetByIdAsync(task.AssigneeId);

            model.AssigneeName = assignee is null ? "-" : assignee.FullName;

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            List<EmployeeViewModel> allEmployees = await _employeeService.GetAllAsync();
            List<SelectListItem> selectList = new List<SelectListItem>();
            List<SelectListItem> emunList = new List<SelectListItem>();
            var taskStatusValues = Enum.GetValues<Data.Enums.TaskStatus>();

            foreach (var employee in allEmployees)
            {
                SelectListItem item = new SelectListItem
                {
                    Text = employee.FullName,
                    Value = employee.Id.ToString()
                };

                selectList.Add(item);
            }

            foreach (var status in taskStatusValues)
            {
                SelectListItem item = new SelectListItem
                {
                    Text = Enum.GetName(status),
                    Value = status.ToString()
                };

                emunList.Add(item);
            }

            ViewBag.Employees = selectList;
            ViewBag.Statuses = emunList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _taskService.CreateAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            TaskViewModel? model = await _taskService.GetByIdAsync(id);

            if (model is null)
            {
                return RedirectToAction("Index");
            }

            List<EmployeeViewModel> allEmployees = await _employeeService.GetAllAsync();
            List<SelectListItem> selectList = new List<SelectListItem>();
            List<SelectListItem> emunList = new List<SelectListItem>();
            var taskStatusValues = Enum.GetValues<Data.Enums.TaskStatus>();

            foreach (var employee in allEmployees)
            {
                SelectListItem item = new SelectListItem
                {
                    Text = employee.FullName,
                    Value = employee.Id.ToString()
                };

                if(model.AssigneeId == employee.Id)
                {
                    item.Selected = true;
                }

                selectList.Add(item);
            }

            foreach (var status in taskStatusValues)
            {
                SelectListItem item = new SelectListItem
                {
                    Text = Enum.GetName(status),
                    Value = status.ToString()
                };

                emunList.Add(item);
            }

            ViewBag.Employees = selectList;
            ViewBag.Statuses = emunList;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _taskService.UpdateAsync(model);
            }
            catch (ArgumentException)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            TaskViewModel? model = await _taskService.GetByIdAsync(id);

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
                await _taskService.DeleteAsync(id);
            }
            catch (ArgumentException)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}

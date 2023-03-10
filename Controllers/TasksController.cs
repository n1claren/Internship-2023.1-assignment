using EmployeeTaskSystem.Models.Tasks;
using EmployeeTaskSystem.Services.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskSystem.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService tService;

        public TasksController(ITaskService taskService)
        {
            this.tService = taskService;
        }

        public IActionResult Add()
        {
            return View(new AddTaskFormModel
            {
                Employees = this.tService.GetAllEmployees()
            });
        }

        [HttpPost]
        public IActionResult Add(AddTaskFormModel task)
        {
            this.tService.AddTask(task.Title, task.Description, task.EmployeeId, task.DueDate);

            return RedirectToAction("Index", "Home");
        }
    }
}

using EmployeeTaskSystem.Data.Models;
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
            return View(new CRUDTaskFormModel
            {
                Employees = this.tService.GetAllEmployees()
            });
        }

        [HttpPost]
        public IActionResult Add(CRUDTaskFormModel task)
        {
            this.tService.AddTask(task.Title, task.Description, task.EmployeeId, task.DueDate);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ListAllTasks()
        {
            var tasks = this.tService.ListAllTasks();

            return View(tasks);
        }

        public IActionResult Edit(int id)
        {
            var employees = this.tService.GetAllEmployees();

            var task = tService.getTaskData(id);

            task.Employees = employees;

            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(int id, CRUDTaskFormModel task) 
        {
            var edited = this.tService.EditTask(id, task.Title, task.Description, task.EmployeeId, task.DueDate);

            if (!edited)
            {
                return BadRequest();
            }

            return RedirectToAction("ListAllTasks", "Tasks");
        }

        public IActionResult Delete(int id)
        {
            var task = this.tService.getTaskData(id);

            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(CRUDTaskFormModel task)
        {
            var deleted = this.tService.DeleteTask(task.Id);

            if (!deleted)
            {
                return BadRequest();
            }

            return RedirectToAction("ListAllTasks", "Tasks");
        }
    }
}

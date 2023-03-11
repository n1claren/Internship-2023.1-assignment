using EmployeeTaskSystem.Data.Models;
using EmployeeTaskSystem.Models.Tasks;
using EmployeeTaskSystem.Services.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        public IActionResult CompletedTasks()
        {
            var completedTasks = this.tService.ListCompletedTasks();

            return View(completedTasks);
        }

        public IActionResult MarkComplete(int id)
        {
            var completed = this.tService.CompleteTask(id);

            if (!completed)
            {
                return BadRequest();
            }

            return RedirectToAction("CompletedTasks", "Tasks");
        }

        public IActionResult DeleteCompleted(int id)
        {
            var completedTask = this.tService.getCompletedTaskData(id);

            return View(completedTask);
        }

        [HttpPost]
        public IActionResult DeleteCompleted(CompletedTaskDTO completedTask) 
        {
            var deleted = this.tService.DeleteCompletedTask(completedTask.Id);

            if (!deleted)
            {
                return BadRequest();
            }

            return RedirectToAction("CompletedTasks", "Tasks");
        }
    }
}

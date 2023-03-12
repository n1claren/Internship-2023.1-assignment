using EmployeeTaskSystem.Data.Models;
using EmployeeTaskSystem.Models.Employees;
using EmployeeTaskSystem.Models.Tasks;
using EmployeeTaskSystem.Services.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskSystem.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        private readonly IStatsService statService;

        public ApiController(IStatsService statService)
            => this.statService = statService;

        [HttpGet]
        [Route("employees")]
        public ActionResult<List<EmployeeDTO>> GetAllEmployeeData()
        {
            var employees = this.statService.GetAllEmployees();

            if (!employees.Any())
            {
                return NotFound();
            }

            return Ok(employees);
        }

        [HttpGet]
        [Route("tasks")]
        public ActionResult<List<TaskDTO>> GetAllTasksData()
        {
            var tasks = this.statService.GetAllTasks();

            if (!tasks.Any())
            {
                return NotFound();
            }

            return Ok(tasks);
        }

        [HttpGet]
        [Route("completedTasks")]
        public ActionResult<List<CompletedTaskDTO>> GetAllCompletedTasksData()
        {
            var completedTasks = this.statService.GetAllCompletedTasks();

            if (!completedTasks.Any())
            {
                return NotFound();
            }

            return Ok(completedTasks);
        }

        [HttpGet]
        [Route("statsCount")]
        public ActionResult<Dictionary<string, int>> GetStatsCount()
            => this.statService.GetStatCount();
    }
}

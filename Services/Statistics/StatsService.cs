using EmployeeTaskSystem.Data;
using EmployeeTaskSystem.Models.Employees;
using EmployeeTaskSystem.Models.Tasks;

namespace EmployeeTaskSystem.Services.Statistics
{
    public class StatsService : IStatsService
    {
        private readonly ApplicationDbContext data;

        public StatsService(ApplicationDbContext data)
            => this.data = data;

        public List<CompletedTaskDTO> GetAllCompletedTasks() 
            => this.data
                   .CompletedTasks
                   .Select(ct => new CompletedTaskDTO
                   {
                       Id = ct.Id,
                       Title = ct.Title,
                       EmployeeId = ct.EmployeeId,
                       EmployeeName = ct.EmployeeName,
                       CompletedOn = ct.CompletedOn
                   })
                   .ToList();

        public List<EmployeeDTO> GetAllEmployees() 
            => this.data
                   .Employees
                   .Select(e => new EmployeeDTO
                   {
                       Id = e.Id,
                       FullName = e.FullName,
                       Email = e.Email,
                       PhoneNumber = e.PhoneNumber,
                       DateOfBirth = e.DateOfBirth,
                       Salary = e.Salary,
                   })
                   .ToList();

        public List<TaskDTO> GetAllTasks()
            => this.data
                   .Tasks
                   .Select(e => new TaskDTO
                   {
                       Id= e.Id,
                       Title = e.Title,
                       Description = e.Description,
                       EmployeeId = e.EmployeeId,
                       EmployeeName = this.data.Employees.Where(x => x.Id == e.EmployeeId).First().FullName,
                       DueDate = e.DueDate
                   })
                   .ToList();

        public Dictionary<string, int> GetStatCount()
        {
            var employees = this.data.Employees.Count();
            var tasks = this.data.Tasks.Count();
            var completedTasks = this.data.CompletedTasks.Count();

            return new Dictionary<string, int>()
            {
                ["employees"] = employees,
                ["tasks"] = tasks,
                ["completedTasks"] = completedTasks
            };
        }
    }
}

using EmployeeTaskSystem.Data;
using EmployeeTaskSystem.Models.Tasks;

namespace EmployeeTaskSystem.Services.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext data;

        public TaskService(ApplicationDbContext data)
            => this.data = data;

        public void AddTask(string title, string description, int EmployeeId, DateTime dueDate)
        {
            var task = new Data.Models.Task
            {
                Title = title,
                Description = description,
                EmployeeId = EmployeeId,
                DueDate = dueDate
            };

            this.data.Tasks.Add(task);
            this.data.SaveChanges();
        }

        public IEnumerable<SelectEmployeeModel> GetAllEmployees()
            => this.data
                   .Employees
                   .Select(e => new SelectEmployeeModel
                   {
                       Id = e.Id,
                       FullName = e.FullName
                   })
                   .ToList();
    }
}

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

        public ListTasksViewModel ListAllTasks()
        {
            var tasks = this.data
                            .Tasks
                            .OrderBy(t => t.Id)
                            .Select(t => new TaskDTO
                            {
                                Id = t.Id,
                                Title = t.Title,
                                Description = t.Description,
                                EmployeeName = t.Employee.FullName,
                                DueDate = t.DueDate
                            })
                            .ToList();

            return new ListTasksViewModel
            {
                Tasks = tasks
            };
        }
    }
}

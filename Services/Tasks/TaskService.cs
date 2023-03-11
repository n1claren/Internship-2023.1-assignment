using EmployeeTaskSystem.Data;
using EmployeeTaskSystem.Data.Models;
using EmployeeTaskSystem.Models.Tasks;
using System.Threading.Tasks;

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

        public bool CompleteTask(int id)
        {
            var task = this.data.Tasks.Where(t => t.Id == id).FirstOrDefault();

            if (task == null)
            {
                return false;
            }

            var completedTask = new CompletedTask
            {
                Title = task.Title,
                EmployeeId = task.EmployeeId,
                EmployeeName = this.data.Employees.Where(e => e.Id == task.EmployeeId).First().FullName,
                CompletedOn = DateTime.UtcNow
            };

            this.data.Tasks.Remove(task);
            this.data.CompletedTasks.Add(completedTask);
            this.data.SaveChanges();

            return true;
        }

        public bool DeleteCompletedTask(int id)
        {
            var task = this.data.CompletedTasks.Where(t => t.Id == id).FirstOrDefault();

            if (task == null)
            {
                return false;
            }

            this.data.CompletedTasks.Remove(task);
            this.data.SaveChanges();

            return true;
        }

        public bool DeleteTask(int id)
        {
            var task = this.data.Tasks.Where(t => t.Id == id).FirstOrDefault();

            if (task == null)
            {
                return false;
            }

            this.data.Tasks.Remove(task);
            this.data.SaveChanges();

            return true;
        }

        public bool EditTask(int id, string title, string description, int employeeId, DateTime dueDate)
        {
            var task = this.data.Tasks.Find(id);

            if (task == null)
            {
                return false;
            }

            task.Title = title;
            task.Description = description;
            task.EmployeeId = employeeId;
            task.DueDate = dueDate;

            this.data.SaveChanges();

            return true;
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

        public CRUDTaskFormModel getTaskData(int id)
            => this.data
                   .Tasks
                   .Where(t => t.Id == id)
                   .Select(t => new CRUDTaskFormModel
                   {
                       Id = t.Id,
                       Title = t.Title,
                       Description = t.Description,
                       EmployeeId = t.EmployeeId,
                       DueDate = t.DueDate
                   })
                   .First();

        public CompletedTaskDTO getCompletedTaskData(int id)
            => this.data
                   .CompletedTasks
                   .Where(t => t.Id == id)
                   .Select(t => new  CompletedTaskDTO
                   {
                       Id = id,
                       Title = t.Title,
                       EmployeeId= t.EmployeeId,
                       EmployeeName = t.EmployeeName,
                       CompletedOn = t.CompletedOn
                   })
                   .First();

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

        public ListCompetedTasksModel ListCompletedTasks()
        {
            var tasks = this.data
                            .CompletedTasks
                            .OrderBy(t => t.Id)
                            .Select(t => new CompletedTaskDTO
                            {
                                Id= t.Id,
                                Title = t.Title,
                                EmployeeId = t.EmployeeId,
                                EmployeeName = t.EmployeeName,
                                CompletedOn = t.CompletedOn
                            })
                            .ToList();

            return new ListCompetedTasksModel
            {
                Tasks = tasks
            };
        }
    }
}

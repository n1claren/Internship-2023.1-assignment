using EmployeeTaskSystem.Models.Tasks;

namespace EmployeeTaskSystem.Services.Tasks
{
    public interface ITaskService
    {
        public void AddTask(string title, string description, int EmployeeId, DateTime dueDate);

        public IEnumerable<SelectEmployeeModel> GetAllEmployees();

        public ListTasksViewModel ListAllTasks();

        public bool EditTask(int id, string title, string description, int employeeId, DateTime dueDate);

        public CRUDTaskFormModel getTaskData(int id);

        public bool DeleteTask(int id);

        public ListCompetedTasksModel ListCompletedTasks();

        public bool CompleteTask(int id);
    }
}

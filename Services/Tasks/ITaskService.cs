using EmployeeTaskSystem.Models.Tasks;

namespace EmployeeTaskSystem.Services.Tasks
{
    public interface ITaskService
    {
        public void AddTask(string title, string description, int EmployeeId, DateTime dueDate);

        public IEnumerable<SelectEmployeeModel> GetAllEmployees();
    }
}

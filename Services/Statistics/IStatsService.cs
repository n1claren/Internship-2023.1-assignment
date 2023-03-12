using EmployeeTaskSystem.Models.Employees;
using EmployeeTaskSystem.Models.Tasks;

namespace EmployeeTaskSystem.Services.Statistics
{
    public interface IStatsService
    {
        public List<EmployeeDTO> GetAllEmployees();

        public List<TaskDTO> GetAllTasks();

        public List<CompletedTaskDTO> GetAllCompletedTasks();

        public Dictionary<string, int> GetStatCount();
    }
}

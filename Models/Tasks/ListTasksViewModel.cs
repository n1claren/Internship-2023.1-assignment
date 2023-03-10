namespace EmployeeTaskSystem.Models.Tasks
{
    public class ListTasksViewModel
    {
        public ListTasksViewModel()
        {
            this.Tasks = new List<TaskDTO>();
        }

        public IEnumerable<TaskDTO> Tasks { get; set; }
    }
}

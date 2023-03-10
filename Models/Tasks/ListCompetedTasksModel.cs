namespace EmployeeTaskSystem.Models.Tasks
{
    public class ListCompetedTasksModel
    {
        public ListCompetedTasksModel()
        {
            this.Tasks = new List<CompletedTaskDTO>();
        }

        public IEnumerable<CompletedTaskDTO> Tasks { get; set; }
    }
}

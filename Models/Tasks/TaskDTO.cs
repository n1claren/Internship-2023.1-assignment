namespace EmployeeTaskSystem.Models.Tasks
{
    public class TaskDTO
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public string Description { get; init; }

        public string EmployeeName { get; init; }

        public DateTime DueDate { get; init; }
    }
}

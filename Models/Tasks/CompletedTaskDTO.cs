namespace EmployeeTaskSystem.Models.Tasks
{
    public class CompletedTaskDTO
    {
        public int Id { get; init; }

        public string Title { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public DateTime CompletedOn { get; set; }
    }
}

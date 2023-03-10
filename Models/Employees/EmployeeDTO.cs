namespace EmployeeTaskSystem.Models.Employees
{
    public class EmployeeDTO
    {
        public int Id { get; init; }

        public string FullName { get; init; }

        public string Email { get; init; }

        public string PhoneNumber { get; init; }

        public DateTime DateOfBirth { get; init; }

        public decimal Salary { get; init; }
    }
}

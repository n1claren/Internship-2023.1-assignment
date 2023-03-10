using EmployeeTaskSystem.Models.Employees;

namespace EmployeeTaskSystem.Services.Employees
{
    public interface IEmployeeService
    {
        public void AddEmployee(string fullName, string email, string phoneNumber, DateTime dateOfBirth, decimal salary);

        public bool EmployeeExists(string email, string phoneNumber);

        public ListEmployeesViewModel ListEmployees();

        public EmployeeDTO GetEmployeeDetails(int id);

        public bool DeleteEmployee(int id);

        public bool EditEmployee(int id, string fullName, string email, string phoneNumber, DateTime dateOfBirth, decimal salary);
    }
}

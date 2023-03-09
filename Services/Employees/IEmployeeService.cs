namespace EmployeeTaskSystem.Services.Employees
{
    public interface IEmployeeService
    {
        public void AddEmployee(string fullName, string email, string phoneNumber, DateTime dateOfBirth, decimal salary);

        public bool EmployeeExists(string email, string phoneNumber); 
    }
}

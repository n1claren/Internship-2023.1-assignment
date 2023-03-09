using EmployeeTaskSystem.Data;
using EmployeeTaskSystem.Data.Models;

namespace EmployeeTaskSystem.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext data;

        public EmployeeService(ApplicationDbContext data) 
            => this.data = data;

        public void AddEmployee(string fullName, string email, string phoneNumber, DateTime dateOfBirth, decimal salary)
        {
            var employee = new Employee
            {
                FullName = fullName,
                Email = email,
                PhoneNumber = phoneNumber,
                DateOfBirth = dateOfBirth,
                Salary = salary
            };

            this.data.Employees.Add(employee);
            this.data.SaveChanges();
        }

        public bool EmployeeExists(string email, string phoneNumber)
        {
            bool emailExists = this.data
                                   .Employees
                                   .Any(e => e.Email == email);

            bool phoneNumberExists = this.data
                                         .Employees
                                         .Any (e => e.PhoneNumber == phoneNumber);

            if (emailExists || phoneNumberExists )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

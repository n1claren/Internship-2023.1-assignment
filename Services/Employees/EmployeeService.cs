using EmployeeTaskSystem.Data;
using EmployeeTaskSystem.Data.Models;
using EmployeeTaskSystem.Models.Employees;

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
            bool emailExists = this.data.Employees.Any(e => e.Email == email);

            bool phoneNumberExists = this.data.Employees.Any (e => e.PhoneNumber == phoneNumber);

            if (emailExists || phoneNumberExists )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public EmployeeDTO GetEmployeeDetails(int id)
        {
            var employee = this.data
                               .Employees
                               .Where(e => e.Id == id)
                               .Select(e => new  EmployeeDTO
                               {
                                   Id = e.Id,
                                   FullName = e.FullName,
                                   Email = e.Email,
                                   PhoneNumber = e.PhoneNumber,
                                   DateOfBirth = e.DateOfBirth,
                                   Salary = e.Salary
                               })
                               .FirstOrDefault();

            return employee;
        }

        public ListEmployeesViewModel ListEmployees()
        {
            var employees = this.data
                                .Employees
                                .OrderBy (e => e.Id)
                                .Select (e => new EmployeeDTO
                                {
                                    Id = e.Id,
                                    FullName = e.FullName,
                                    Email = e.Email,
                                    PhoneNumber = e.PhoneNumber,
                                    DateOfBirth = e.DateOfBirth,
                                    Salary = e.Salary
                                })
                                .ToList ();

            return new ListEmployeesViewModel
            {
                Employees = employees
            };
        }
    }
}

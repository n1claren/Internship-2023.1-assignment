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

        public bool DeleteEmployee(int id)
        {
            var epmloyee = this.data.Employees.Where(v => v.Id == id).FirstOrDefault();

            if (epmloyee == null)
            {
                return false;
            }

            this.data.Employees.Remove(epmloyee);
            this.data.SaveChanges();

            return true;
        }

        public bool EditEmployee(int id, string fullName, string email, string phoneNumber, DateTime dateOfBirth, decimal salary)
        {
            var employee = this.data.Employees.Find(id);

            if (employee == null)
            {
                return false;
            }

            employee.FullName = fullName;
            employee.Email = email;
            employee.PhoneNumber = phoneNumber;
            employee.DateOfBirth = dateOfBirth;
            employee.Salary = salary;

            this.data.SaveChanges();

            return true;
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

        public ListTop5EmployeesModel GetTop5Employees()
        {
            var startDate = DateTime.Today.AddMonths(-1);

            var completedTasks = this.data
                                     .CompletedTasks
                                     .Where(ct => ct.CompletedOn > startDate)
                                     .ToList();

            var top5model = new ListTop5EmployeesModel();

            foreach (var task in completedTasks)
            {
                if (top5model.EmployeesTasksCompleted.Any(e => e.Id == task.EmployeeId))
                {
                    top5model.EmployeesTasksCompleted.Where(e => e.Id == task.EmployeeId).First().TasksCompleted += 1;
                }
                else
                {
                    var employee = new EmployeeTasksCompletedModel
                    {
                        Id = task.EmployeeId,
                        FullName = task.EmployeeName,
                        TasksCompleted = 1
                    };

                    top5model.EmployeesTasksCompleted.Add(employee);
                }
            }



            top5model.EmployeesTasksCompleted = top5model.EmployeesTasksCompleted
                                                         .OrderByDescending(e => e.TasksCompleted)
                                                         .Take(5)
                                                         .ToList();

            return top5model;
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

using EmployeeTaskSystem.Models.Employees;
using EmployeeTaskSystem.Services.Employees;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService eService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.eService = employeeService;
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AddEmployeeFormModel employee)
        {
            bool employeeExists = this.eService.EmployeeExists(employee.Email, employee.PhoneNumber);

            if (employeeExists)
            {
                this.ModelState.AddModelError(string.Empty, "Employee is already registered in the system.");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            this.eService.AddEmployee(employee.FullName, employee.Email, employee.PhoneNumber, employee.DateOfBirth, employee.Salary);

            return RedirectToAction("Index", "Home");
        }
    }
}

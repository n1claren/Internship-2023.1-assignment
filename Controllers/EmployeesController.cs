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

        public IActionResult ListEmployees()
        {
            var employees = this.eService.ListEmployees();

            return View(employees);
        }

        public IActionResult Details(int id)
        {
            var employee = this.eService.GetEmployeeDetails(id);

            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            var employee = this.eService.GetEmployeeDetails(id);

            return View(new AddEmployeeFormModel
            {
                FullName = employee.FullName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                DateOfBirth = employee.DateOfBirth,
                Salary = employee.Salary
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, AddEmployeeFormModel employee)
        {
            var edited = this.eService.EditEmployee(id, 
                                                    employee.FullName, 
                                                    employee.Email, 
                                                    employee.PhoneNumber, 
                                                    employee.DateOfBirth, 
                                                    employee.Salary);

            if (!edited)
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            var employee = this.eService.GetEmployeeDetails(id);

            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(EmployeeDTO employee)
        {
            var deleted = this.eService.DeleteEmployee(employee.Id);

            if (!deleted)
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

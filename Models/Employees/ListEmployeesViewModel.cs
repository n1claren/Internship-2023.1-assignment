namespace EmployeeTaskSystem.Models.Employees
{
    public class ListEmployeesViewModel
    {
        public ListEmployeesViewModel()
        {
            this.Employees = new List<EmployeeDTO>();
        }

        public IEnumerable<EmployeeDTO> Employees { get; set; }
    }
}

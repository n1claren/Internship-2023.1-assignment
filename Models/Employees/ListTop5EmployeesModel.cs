namespace EmployeeTaskSystem.Models.Employees
{
    public class ListTop5EmployeesModel
    {
        public ListTop5EmployeesModel()
        {
            this.EmployeesTasksCompleted = new List<EmployeeTasksCompletedModel>();
        }

        public List<EmployeeTasksCompletedModel> EmployeesTasksCompleted { get; set; }
    }
}

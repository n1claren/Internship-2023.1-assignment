using System.ComponentModel.DataAnnotations;

using static EmployeeTaskSystem.Data.DataConstants;

namespace EmployeeTaskSystem.Models.Tasks
{
    public class AddTaskFormModel
    {
        public AddTaskFormModel()
        {
            this.Employees = new List<SelectEmployeeModel>();
        }

        [StringLength(TaskTitleMaxLength, MinimumLength = TextMinLength, ErrorMessage = "Task Title should be between {2} and {1} symbols!")]
        public string Title { get; init; }

        [StringLength(TextMaxLength, MinimumLength = TextMinLength, ErrorMessage = "Description should be between {2} and {1} symbols!")]
        public string Description { get; init; }

        [Display(Name = "Employee")]
        public int EmployeeId { get; init; }

        [Display(Name = "Due Date")]
        public DateTime DueDate { get; init; }

        public IEnumerable<SelectEmployeeModel> Employees { get; init; }
    }
}

using System.ComponentModel.DataAnnotations;

using static EmployeeTaskSystem.Data.DataConstants;

namespace EmployeeTaskSystem.Models.Employees
{
    public class AddEmployeeFormModel
    {
        [Display(Name = "Full Name")]
        [StringLength(TextMaxLength, MinimumLength = TextMinLength, ErrorMessage = "Employee Full Name should be between {2} and {1} symbols!")]
        public string FullName { get; init; }

        [StringLength(TextMaxLength, MinimumLength = TextMinLength, ErrorMessage = "Employee Email should be between {2} and {1} symbols!")]
        public string Email { get; init; }

        [Display(Name = "Phone Number")]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = "Employee Phone Number should be between {2} and {1} symbols!")]
        public string PhoneNumber { get; init; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; init; }

        [Required]
        public decimal Salary { get; init; }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static EmployeeTaskSystem.Data.DataConstants;

namespace EmployeeTaskSystem.Data.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Tasks = new List<Task>();
        }

        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(TextMaxLength)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(TextMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [Column(TypeName = DecimalColumn)]
        public decimal Salary { get; set; }

        public IEnumerable<Task> Tasks { get; init; }
    }
}

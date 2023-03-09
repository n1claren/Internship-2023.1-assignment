using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskSystem.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime DueDate { get; set; }
    }
}

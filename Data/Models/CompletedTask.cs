using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskSystem.Data.Models
{
    public class CompletedTask
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(255)]
        public string EmployeeName { get; set; }

        public DateTime CompletedOn { get; set; }
    }
}

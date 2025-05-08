using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeGroupHealthInsuranceManagementSystem.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Policy")]
        public int PolicyId { get; set; }
        public Policy Policy { get; set; }

        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        [MaxLength(10)]
        public string Status { get; set; } // Use string for ENUM for simplicity initially
    }
}

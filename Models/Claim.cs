using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeGroupHealthInsuranceManagementSystem.Models
{
    public class Claim
    {
        [Key]
        public int ClaimId { get; set; }

        [ForeignKey("Enrollment")]
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal ClaimAmount { get; set; }

        public string ClaimReason { get; set; }

        [DataType(DataType.Date)]
        public DateTime ClaimDate { get; set; }

        [MaxLength(15)]
        public string ClaimStatus { get; set; } // Use string for ENUM for simplicity initially
    }
}

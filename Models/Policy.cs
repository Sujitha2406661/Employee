using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeGroupHealthInsuranceManagementSystem.Models
{
    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }

        [Required]
        [MaxLength(100)]
        public string PolicyName { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal CoverageAmount { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal PremiumAmount { get; set; }

        public string PolicyType { get; set; } // Use string for ENUM for simplicity initially, consider Enum type later
    }
}

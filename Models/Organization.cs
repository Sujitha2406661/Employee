using System.ComponentModel.DataAnnotations;

namespace EmployeeGroupHealthInsuranceManagementSystem.Models
{
    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }

        [Required]
        [MaxLength(100)]
        public string OrganizationName { get; set; }

        [MaxLength(100)]
        public string ContactPerson { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string ContactEmail { get; set; }
    }
}

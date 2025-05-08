﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeGroupHealthInsuranceManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        public string Address { get; set; }

        [MaxLength(50)]
        public string Designation { get; set; }

        [ForeignKey("Organization")]
        public int? OrganizationId { get; set; } // Make nullable to allow employees without an organization initially
        public Organization? Organization { get; set; } // Navigation property
    }
}

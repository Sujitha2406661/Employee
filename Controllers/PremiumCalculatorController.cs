using Microsoft.AspNetCore.Mvc;
using EmployeeGroupHealthInsuranceManagementSystem.Services; // Assuming you'll create this service
using EmployeeGroupHealthInsuranceManagementSystem.Data; // For database access
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using EmployeeGroupHealthInsuranceManagementSystem.Data;

namespace Employee_Group_Health_Insurance_Management_System.Controllers
{
    public class PremiumCalculatorController : Controller
    {
        private readonly IPremiumCalculatorService _premiumCalculatorService;
        private readonly ApplicationDbContext _context;

        public PremiumCalculatorController(IPremiumCalculatorService premiumCalculatorService, ApplicationDbContext context)
        {
            _premiumCalculatorService = premiumCalculatorService;
            _context = context;
        }

        // GET: /PremiumCalculator/CalculatePremium
        [HttpGet]
        public async Task<IActionResult> CalculatePremium(int employeeId, int policyId)
        {
            // Input validation - improved
            if (employeeId <= 0)
            {
                return BadRequest(new { Message = "Employee ID must be greater than zero." }); // Return JSON
            }
            if (policyId <= 0)
            {
                return BadRequest(new { Message = "Policy ID must be greater than zero." });  // Return JSON
            }

            // Fetch required data
            var employee = await _context.Employees.Include(e => e.Organization).FirstOrDefaultAsync(e => e.EmployeeId == employeeId); // Eager load
            var policy = await _context.Policies.FindAsync(policyId);

            if (employee == null)
            {
                return NotFound(new { Message = "Employee not found." }); // Return JSON
            }
            if (policy == null)
            {
                return NotFound(new { Message = "Policy not found." }); // Return JSON
            }

            try
            {
                // Calculate premium using the service
                decimal premium = _premiumCalculatorService.CalculatePremium(employee, policy);

                // Return the result
                return Ok(new { Premium = premium }); // Return JSON
            }
            catch (Exception ex)
            {
                // Log the exception (important for debugging)
                Console.Error.WriteLine($"Error calculating premium: {ex.Message}");
                return StatusCode(500, new { Message = "An error occurred while calculating the premium." }); // Return JSON
            }
        }
    }
}


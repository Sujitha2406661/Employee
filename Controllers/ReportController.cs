using EmployeeGroupHealthInsuranceManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeGroupHealthInsuranceManagementSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly ApplicationDbContext _context;

        public ReportController(IReportService reportService, ApplicationDbContext context)
        {
            _reportService = reportService;
            _context = context;
        }

        // GET: /Report/GenerateEmployeeReport
        public async Task<IActionResult> GenerateEmployeeReport()
        {
            var employees = await _context.Employees.Include(e => e.Organization).ToListAsync();
            var reportData = _reportService.GenerateEmployeeReport(employees);
            return View(reportData); // Return to a view
        }

        // GET: /Report/GeneratePolicyReport
        public async Task<IActionResult> GeneratePolicyReport()
        {
            var policies = await _context.Policies.ToListAsync();
            var reportData = _reportService.GeneratePolicyReport(policies);
            return View(reportData);
        }

        // GET: /Report/ExportReport
        public async Task<IActionResult> ExportReport(string reportType, string format)
        {
            if (string.IsNullOrEmpty(reportType) || string.IsNullOrEmpty(format))
            {
                return BadRequest(new { Message = "Report type and format are required." });
            }

            byte[] fileBytes = null;
            string fileName = "";
            string contentType = "";

            if (reportType.ToLower() == "employee")
            {
                var employees = await _context.Employees.Include(e => e.Organization).ToListAsync();
                var employeeReportData = _reportService.GenerateEmployeeReport(employees);
                fileName = "EmployeeReport";

                if (format.ToLower() == "excel")
                {
                    fileBytes = _reportService.ExportToExcel(employeeReportData);
                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    fileName += ".xlsx";
                }
                else if (format.ToLower() == "pdf")
                {
                    fileBytes = _reportService.ExportToPdf(employeeReportData);
                    contentType = "application/pdf";
                    fileName += ".pdf";
                }
                else
                {
                    return BadRequest(new { Message = "Invalid format. Supported formats are Excel and PDF." });
                }
            }
            else if (reportType.ToLower() == "policy")
            {
                var policies = await _context.Policies.ToListAsync();
                var policyReportData = _reportService.GeneratePolicyReport(policies);
                fileName = "PolicyReport";
                if (format.ToLower() == "excel")
                {
                    fileBytes = _reportService.ExportToExcel(policyReportData);
                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    fileName += ".xlsx";
                }
                else if (format.ToLower() == "pdf")
                {
                    fileBytes = _reportService.ExportToPdf(policyReportData);
                    contentType = "application/pdf";
                    fileName += ".pdf";
                }
                else
                {
                    return BadRequest(new { Message = "Invalid format. Supported formats are Excel and PDF." });
                }
            }
            else
            {
                return BadRequest(new { Message = "Invalid report type. Supported types are Employee and Policy." });
            }
            if (fileBytes == null)
            {
                return Problem(new { Message = "Error generating the report" }.ToString(), statusCode: 500);
            }

            return File(fileBytes, contentType, fileName);
        }
    }
}

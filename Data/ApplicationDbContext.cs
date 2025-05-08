using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design; // Often useful, but not strictly needed for the constructor fix
using EmployeeGroupHealthInsuranceManagementSystem.Models;

// Make sure this namespace matches where your DbContext is defined
namespace EmployeeGroupHealthInsuranceManagementSystem.Data
{
    // Your DbContext class should inherit from DbContext
    public class ApplicationDbContext : DbContext
    {
        // This is the required constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            // The configuration (like the connection string) is passed in the 'options' object
            // You typically don't need code inside this constructor body for basic setup
        }
    // Your DbContext class should inherit from DbContext
public DbSet<EmployeeGroupHealthInsuranceManagementSystem.Models.Employee> Employee { get; set; } = default!;
    // Your DbContext class should inherit from DbContext
public DbSet<EmployeeGroupHealthInsuranceManagementSystem.Models.Enrollment> Enrollment { get; set; } = default!;
    // Your DbContext class should inherit from DbContext
public DbSet<EmployeeGroupHealthInsuranceManagementSystem.Models.Organization> Organization { get; set; } = default!;
    // Your DbContext class should inherit from DbContext
public DbSet<EmployeeGroupHealthInsuranceManagementSystem.Models.Policy> Policy { get; set; } = default!;
    // Your DbContext class should inherit from DbContext
public DbSet<EmployeeGroupHealthInsuranceManagementSystem.Models.Claim> Claim { get; set; } = default!;

        // Add your DbSet properties here, e.g.:
        // public DbSet<YourModel> YourModels { get; set; }
        // public DbSet<Employee> Employees { get; set; }
        // public DbSet<HealthInsurance> HealthInsurances { get; set; }
    }

    // This part (DbContextFactory) is often added to help with migrations,
    // but isn't strictly necessary just to fix the constructor error in Program.cs.
    // If you need migrations, you might add something like this:
    /*
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // This is just for design time (like migrations)
            // The connection string here might be a hardcoded dummy or read from elsewhere
            // For simplicity, you might need to replicate the connection string logic from Program.cs
             var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
             // Replace with your actual connection string or configuration loading for design time
             optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=YourDesignDb;Trusted_Connection=True;MultipleActiveResultSets=true");

             return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
    */
}
using System.ComponentModel.DataAnnotations;

namespace WorkManager.Business.ViewModels.Employee
{
    public class EmployeeViewModel 
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public decimal? MonthlySalary { get; set; }
    }
}

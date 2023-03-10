using System.ComponentModel.DataAnnotations;

namespace WorkManager.Data.Entities
{
    public class Employee : BaseEntity
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal MonthlySalary { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using WorkManager.Data.Enums;

namespace WorkManager.Data.Entities
{
    public class Task : BaseEntity
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }

        [MinLength(20)]
        public string? Description { get; set; }

        public Employee Assignee { get; set; }
        public DateTime? DueDate { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public DateTime? DateOfCompletion { get; set; }
    }
}

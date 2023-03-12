using System.ComponentModel.DataAnnotations;
using WorkManager.Business.ViewModels.Employee;

namespace WorkManager.Business.ViewModels.Task
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }

        [MinLength(20)]
        public string? Description { get; set; }

        public int AssigneeId { get; set; }
        public DateTime? DueDate { get; set; }
    }
}

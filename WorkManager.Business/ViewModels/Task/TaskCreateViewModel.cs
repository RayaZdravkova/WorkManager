using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager.Business.ViewModels.Task
{
    public class TaskCreateViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }

        [MinLength(20)]
        public string? Description { get; set; }

        public int AssigneeId { get; set; }
        public DateTime? DueDate { get; set; }
    }
}

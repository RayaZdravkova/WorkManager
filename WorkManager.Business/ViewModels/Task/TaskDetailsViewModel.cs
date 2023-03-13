using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager.Business.ViewModels.Task
{
    public class TaskDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }

        [MinLength(20)]
        public string? Description { get; set; }

        public string AssigneeName { get; set; }
        public DateTime? DueDate { get; set; }
        public Data.Enums.TaskStatus Status { get; set; }

        public DateTime? DateOfCompletion { get; set; }
    }
}

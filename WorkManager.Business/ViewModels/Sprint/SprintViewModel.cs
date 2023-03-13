using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkManager.Business.ViewModels.Sprint
{
    public class SprintViewModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Target { get; set; }
    }
}

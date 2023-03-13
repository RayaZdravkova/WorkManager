using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager.Business.ViewModels.Sprint
{
    public class SprintCreateViewModel
    {
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

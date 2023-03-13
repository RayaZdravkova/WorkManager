using System.ComponentModel.DataAnnotations;

namespace WorkManager.Data.Entities
{
    public class Sprint : BaseEntity
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

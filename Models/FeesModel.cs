using System.ComponentModel.DataAnnotations;

namespace mvc_btech.Models
{
    public class FeesModel
    {
        [Key]
        public int fees_id { get; set; }

        [Required]
        public int student_id { get; set; }

        [Required(ErrorMessage = "Enter total amount")]
        public decimal total_amount { get; set; }

        [Required(ErrorMessage = "Enter paid amount")]
        public decimal paid_amount { get; set; }

        public decimal remaining_amount { get; set; }

        [Required]
        public DateTime payment_date { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace mvc_btech.Models
{
    public class ExamModel
    {
        [Key]
        public int exam_id { get; set; }

        [Required]
        public int student_id { get; set; }

        [Required(ErrorMessage = "Enter subject")]
        public string? subject { get; set; }

        [Required(ErrorMessage = "Enter marks")]
        public int marks { get; set; }

        [Required]
        public DateTime exam_date { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace mvc_btech.Models
{
    public class CourseModel
    {
        [Key]
        public int course_id { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string? coursename { get; set; }

        [Required]
        [Display(Name = "Duration (Months)")]
        public int duration { get; set; }

        [Required]
        [Display(Name = "Course Fees")]
        public decimal fees { get; set; }
    }
}

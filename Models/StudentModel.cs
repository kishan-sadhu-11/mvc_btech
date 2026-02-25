using System.ComponentModel.DataAnnotations;

namespace mvc_btech.Models
{
    public class StudentModel
    {
        [Key]
        public int student_id { get; set; }

        [Required(ErrorMessage ="enter the name")]
        public required string  studentname { get; set; }

        [Required(ErrorMessage ="enter the branch ")]
        public string? studentbranch { get; set; }

        [EmailAddress,Required(ErrorMessage ="enter valid email")]
        public string? student_email {  get; set; }

        [Required(ErrorMessage ="enter the DateOfBirth")]
        public DateOnly DOB {  get; set; }

        [Required(ErrorMessage ="enter the city")]
        public string? city {  get; set; }
    }
}

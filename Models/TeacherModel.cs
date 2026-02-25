using System.ComponentModel.DataAnnotations;

namespace mvc_btech.Models
{
    public class TeacherModel
    {
        [Key]
        public int teacher_id { get; set; }

        [Required(ErrorMessage = "Enter teacher name")]
        public string? teacher_name { get; set; }

        [Required(ErrorMessage = "Enter subject")]
        public string? subject { get; set; }

        [EmailAddress, Required(ErrorMessage = "Enter valid email")]
        public string? email { get; set; }

        [Required(ErrorMessage = "Enter phone number")]
        public string? phone { get; set; }

        [Required(ErrorMessage = "Enter city")]
        public string? city { get; set; }
    }
}

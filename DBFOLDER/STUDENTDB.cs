using Microsoft.EntityFrameworkCore;
using mvc_btech.Models;
namespace mvc_btech.DBFOLDER
{
    public class STUDENTDB : DbContext
    {
        public STUDENTDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<StudentModel> students { get; set; }
        public DbSet<TeacherModel> teachers { get; set; }
        public DbSet<FeesModel> fees { get; set; }
        public DbSet<ExamModel> exams { get; set; }
        public DbSet<CourseModel> courses { get; set; }
    }
}

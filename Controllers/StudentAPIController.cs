using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_btech.DBFOLDER;
using mvc_btech.Models;

namespace mvc_btech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly STUDENTDB db;

        public StudentAPIController(STUDENTDB db)
        {
            this.db = db;
        }

        // ✅ GET: api/studentapi
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await db.students.ToListAsync();
            return Ok(students);
        }

        // ✅ GET: api/studentapi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await db.students.FindAsync(id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        // ✅ POST: api/studentapi
        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentModel s)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await db.students.AddAsync(s);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent),
                                   new { id = s.student_id }, s);
        }

        // ✅ PUT: api/studentapi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentModel s)
        {
            if (id != s.student_id)
                return BadRequest();

            db.Entry(s).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return NoContent();
        }

        // ✅ DELETE: api/studentapi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await db.students.FindAsync(id);

            if (student == null)
                return NotFound();

            db.students.Remove(student);
            await db.SaveChangesAsync();

            return NoContent();
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_btech.DBFOLDER;

namespace mvc_btech.Controllers
{
    public class ExamController : Controller
    {
        private readonly STUDENTDB db;

        public ExamController(STUDENTDB db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var exams = await db.exams.ToListAsync();
            return View(exams);
        }
    }
}

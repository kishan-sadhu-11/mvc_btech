using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_btech.DBFOLDER;
using mvc_btech.Models;

namespace mvc_btech.Controllers
{
    public class TeacherController : Controller
    {
        private readonly STUDENTDB db;

        public TeacherController(STUDENTDB db)
        {
            this.db = db;
        }

        public async Task<IActionResult> index()
        {
            var teachers = await db.teachers.ToListAsync();
            return View(teachers);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TeacherModel t)
        {
            if (ModelState.IsValid)
            {
                db.teachers.Add(t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t);
        }
    
}
}


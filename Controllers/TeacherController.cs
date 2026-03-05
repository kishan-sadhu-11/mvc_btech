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

        public async Task<IActionResult> Index()
        {
            var teachers = await db.teachers.ToListAsync();
            return View(teachers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TeacherModel t)
        {
            if (ModelState.IsValid)
            {
                db.teachers.Add(t);
                db.SaveChanges();
                TempData["msg"] = "Teacher Added Successfully";
                return RedirectToAction("Index");
            }
            return View(t);
        }
    }
}

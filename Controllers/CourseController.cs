using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_btech.DBFOLDER;
using mvc_btech.Models;

namespace mvc_btech.Controllers
{
    public class CourseController : Controller
    {
        private readonly STUDENTDB db;

        public CourseController(STUDENTDB db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await db.courses.ToListAsync();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CourseModel c)
        {
            if (ModelState.IsValid)
            {
                db.courses.Add(c);
                db.SaveChanges();
                TempData["msg"] = "Course Added Successfully";
                return RedirectToAction("Index");
            }
            return View(c);
        }
    }
}

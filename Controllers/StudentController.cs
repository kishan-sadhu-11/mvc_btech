using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_btech.DBFOLDER;
using mvc_btech.Models;

namespace mvc_btech.Controllers
{
    public class StudentController : Controller
    {
        private STUDENTDB db;

        public StudentController(STUDENTDB db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult add(StudentModel s)
        {
            if (ModelState.IsValid) 
            {
                db.students.Add(s);
                db.SaveChanges();
                //HttpContext.Session.Set("School","rku");
                TempData["msg"] = "Student Added Successfully";
                return RedirectToAction("Create");
            }
            return View();
        }
        //display all data 
        public async Task< IActionResult> Create()
        {
            var students= await db.students.ToListAsync();

            return View(students);
        }
        
    }
}

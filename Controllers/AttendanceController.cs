using Microsoft.AspNetCore.Mvc;

namespace mvc_btech.Controllers
{
    public class AttendanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

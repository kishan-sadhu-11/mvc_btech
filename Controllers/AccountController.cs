using Microsoft.AspNetCore.Mvc;
using mvc_btech.DBFOLDER;

namespace mvc_btech.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}

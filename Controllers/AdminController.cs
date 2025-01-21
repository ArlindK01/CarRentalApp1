using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CarRentalApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") == null || HttpContext.Session.GetString("Role") != "Admin")
            {
                return Redirect("/auth/login.html");
            }
            return View();
        }

        public IActionResult ManageCars()
        {
            if (HttpContext.Session.GetString("User") == null || HttpContext.Session.GetString("Role") != "Admin")
            {
                return Redirect("/auth/login.html");
            }
            return View();
        }

        public IActionResult ManageBookings()
        {
            if (HttpContext.Session.GetString("User") == null || HttpContext.Session.GetString("Role") != "Admin")
            {
                return Redirect("/auth/login.html");
            }
            return View();
        }
    }
}

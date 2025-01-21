using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CarRentalApp.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Controllers
{
    public class CustomerBookingsController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerBookingsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("User") == null || HttpContext.Session.GetString("Role") != "Customer")
            {
                return Redirect("/auth/login.html");
            }

            var userEmail = HttpContext.Session.GetString("User");
            var bookings = await _context.Bookings
                                .Include(b => b.Car)
                                .Include(b => b.Customer)
                                .Where(b => b.Customer.Email == userEmail)
                                .ToListAsync();

            return View(bookings);
        }
    }
}

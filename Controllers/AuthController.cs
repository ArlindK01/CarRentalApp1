using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CarRentalApp.Data;
using CarRentalApp.Models;

public class AuthController : Controller
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return PhysicalFile("wwwroot/auth/login.html", "text/html");
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Email == email && c.Password == password);
        if (customer != null)
        {
            HttpContext.Session.SetString("User", email);
            return RedirectToAction("Index", "Home");
        }
        return Redirect("/auth/login.html?error=1");
    }

    public IActionResult Register()
    {
        return PhysicalFile("wwwroot/auth/register.html", "text/html");
    }

    [HttpPost]
    public IActionResult Register(string email, string password)
    {
        var newCustomer = new Customer { Email = email, Password = password, Role = "Customer" };
        _context.Customers.Add(newCustomer);
        _context.SaveChanges();
        return Redirect("/auth/login.html?registered=1");
    }


    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Redirect("/auth/login.html");
    }
}
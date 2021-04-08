using EmployeeCrud.Data;
using EmployeeCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeCrudContext _context;
        public const string SessionKey= "Id";


        public HomeController(ILogger<HomeController> logger,EmployeeCrudContext emp)
        {
            _logger = logger;
            _context = emp;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetInt32(SessionKey,0);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login(string Email,string Password)
        {
            
            var data = _context.User.Where(m=>m.Email == Email && m.Password == Password).FirstOrDefault();
            if(data != null)
            {
                HttpContext.Session.SetInt32(SessionKey,data.Id);
                return RedirectToAction("Index", "Employees");
            }
            else
            {

                TempData["msg"] = "Login Failed......!";
                return RedirectToAction(nameof(Index));
            }
          
        }
    }
}

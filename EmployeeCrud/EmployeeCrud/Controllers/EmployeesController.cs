using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeCrud.Data;
using EmployeeCrud.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeCrud.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeCrudContext _context;
      
        public EmployeesController(EmployeeCrudContext context)
        {
           
            _context = context;
        }
        public List<string> Department = new List<string>()
        {
            "Software Developement","Web Designer","Tester"
        };
        public List<string> Manager = new List<string>()
        {
            "Willim","John","Doe"
        };
        // GET: Employees
        public async Task<IActionResult> Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32("Id");
            if (ViewBag.id > 0)
            {
                return View(await _context.Employee.ToListAsync());
            }
            else
            {
                TempData["msg"] = "Please Login First Then You Should Navigate To Get Data";
                return RedirectToAction("Index", "Home");
            }
            
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("Id");
            if (ViewBag.id > 0)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employee = await _context.Employee
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }

                return View(employee);
            }
            else
            {
                TempData["msg"] = "Please Login First Then You Should Navigate To Details Of Data";
                return RedirectToAction("Index", "Home");
            }
           
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewBag.id = HttpContext.Session.GetInt32("Id");
            if (ViewBag.id > 0)
            {
                ViewBag.dept = Department;
                ViewBag.manager = Manager;
                return View();
            }
            else
            {
                TempData["msg"] = "Please Login First Then You Should Navigate To Add Data";
                return RedirectToAction("Index", "Home");
            }
           
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Department,Salary,Manager,Phone,Email")] Employee employee)
        {
            ViewBag.id = HttpContext.Session.GetInt32("Id");
            if (ViewBag.id > 0)
            {
                if (ModelState.IsValid)
                {
                    employee.IsManager = true;
                    _context.Add(employee);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "New Employee Added Success.....";
                    return RedirectToAction(nameof(Index));
                }
                return View(employee);
            }
            else
            {
                TempData["msg"] = "Please Login First Then You Should Navigate To Add Data";
                return RedirectToAction("Index", "Home");
            }
            
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("Id");
            if (ViewBag.id > 0)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employee = await _context.Employee.FindAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }
                ViewBag.dept = Department;
                ViewBag.manager = Manager;
                return View(employee);
            }
            else
            {
                TempData["msg"] = "Please Login First Then You Should Navigate To Edit Data";
                return RedirectToAction("Index", "Home");
            }
          
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Department,Salary,Manager,Phone,Email")] Employee employee)
        {
            ViewBag.id = HttpContext.Session.GetInt32("Id");
            if (ViewBag.id > 0)
            {
                if (id != employee.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        employee.IsManager = true;
                        _context.Update(employee);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EmployeeExists(employee.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    TempData["success"] = "Employee's Data Edit Success.....";
                    return RedirectToAction(nameof(Index));
                }
                return View(employee);
            }
            else
            {
                TempData["msg"] = "Please Login First Then You Should Navigate To Edit Data";
                return RedirectToAction("Index", "Home");
            }
          
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("Id");
            if (ViewBag.id > 0)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employee = await _context.Employee
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }

                return View(employee);
            }
            else
            {
                TempData["msg"] = "Please Login First Then You Should Navigate To Delete Data";
                return RedirectToAction("Index", "Home");
            }
            
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("Id");
            if (ViewBag.id > 0)
            {
                var employee = await _context.Employee.FindAsync(id);
                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();
                TempData["success"] = "Employee's Data Delete Success.....";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["msg"] = "Please Login First Then You Should Navigate To Delete Data";
                return RedirectToAction("Index", "Home");
            }
          
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}

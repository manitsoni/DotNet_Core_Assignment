using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessEntities.Models;
using Business.Manager;
using Business.Manager.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMS.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager context;
        private readonly IDepartmentManager departmentData;
        public List<string> Manager = new List<string>()
        {
            "Willim","John","Doe"
        };
        public EmployeeController(IEmployeeManager employee,IDepartmentManager departmentManager)
        {
            context = employee;
            departmentData = departmentManager;
        }
        public IActionResult Index()
        {
            var data = context.GetEmployees().ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            ViewBag.department = new SelectList(departmentData.GetDepartments(),"Id","Name");
            ViewBag.manager = context.GetManager().Select(m=>m.Name).ToList(); 
            return View();
        }
        enum Action
        {
            Add,
            Update,

        }

        [HttpPost]
       
        public IActionResult Create(Employee emp)
        {
            try
            {
                Action act;
                if (emp.Id == 0)
                {
                    act = Action.Add;
                }
                else
                {
                    act = Action.Update;
                }
                context.AddUpdateEmployee(emp);
                if (act == Action.Update)
                {
                    TempData["message"] = "Employee Update Success...";
                }
                else
                {
                    TempData["message"] = "Employee Added Success...";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IActionResult Edit(int id)
        {
            try
            {
                ViewBag.department = new SelectList(departmentData.GetDepartments(), "Id", "Name");
                ViewBag.manager = context.GetManager().Select(m => m.Name).ToList();
                var data = context.GetEmployee(id);
                return View(data);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IActionResult Delete(int id)
        {
            context.DeleteEmployee(id);
            TempData["message"] = "Employee Delete Success...";
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var data = context.GetEmployee(id);
            return View(data);
        }
    }
}

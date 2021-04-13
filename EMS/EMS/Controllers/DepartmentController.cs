using Business.Manager.Interface;
using BusinessEntities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentManager department;
        public DepartmentController(IDepartmentManager dept)
        {
            department = dept;
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
            ViewBag.data = department.GetDepartments().ToList();
            return View();
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var data = department.GetDepartment(id);
            return View(data);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department dept)
        {
            try
            {
                
                if (dept.Id > 0)
                {
                    bool Update = department.UpdateDepartment(dept);
                    return RedirectToAction("Index");
                }
                else
                {
                    bool Added = department.AddDepartment(dept);
                    if (Added == true)
                    {
                        TempData["message"] = "Department Added Success...";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["message"] = "Unable to create new department...";
                        return RedirectToAction("Index");
                    }
                }
              
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = department.GetDepartment(id);
            return View(data);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department dept)
        {
            try
            {
                bool Update = department.UpdateDepartment(dept);
                TempData["message"] = "Update success...";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            bool Delete = department.Delete(id);
            TempData["message"] = "Delete success...";
            return RedirectToAction(nameof(Index));
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

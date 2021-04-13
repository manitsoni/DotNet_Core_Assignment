using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Models;
using Data.Repository.Interface;

namespace Data.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeManagementContext db;
        public DepartmentRepository(EmployeeManagementContext context)
        {
            db = context;
        }
        public bool AddDepartment(Department dept)
        {
            int isAvailable = db.Departments.Where(m => m.Name == dept.Name).Count();
            if (isAvailable > 0)
            {
                return false;
            }
            else
            {
                db.Departments.Add(dept);
                return db.SaveChanges() > 0;
            }
            
        }

        public bool Delete(int id)
        {
            Department data = db.Departments.Find(id);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public Department GetDepartment(int id)
        {
            Department data = db.Departments.Find(id);
            return data;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return db.Departments.ToList();
        }

        public bool UpdateDepartment(Department department)
        {
            db.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}

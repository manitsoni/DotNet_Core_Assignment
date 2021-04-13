using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Models;
using BusinessEntities;
using Data.Repository.Interface;
namespace Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementContext db;
        public EmployeeRepository(EmployeeManagementContext context)
        {
            db = context;
        }
      
       
        public bool AddUpdateEmployee(Employee employee)
        {
            if (employee.Id != 0)
            {
                if (employee.Manager == null)
                {
                    employee.Manager = employee.Name;
                }
               
                db.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            else
            {
                db.Employees.Add(employee);
                return db.SaveChanges() > 0;
            }
        }

        public bool DeleteEmployee(int id)
        {
            Employee data = db.Employees.Find(id);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return db.Departments.ToList();
        }

        public Employee GetEmployee(int id)
        {
            Employee data = db.Employees.Find(id);
            return data;
        }

        public IEnumerable<GetEmployee> GetEmployees()
        {
            try
            {
                var Data = (from em in db.Employees
                            join dp in db.Departments on em.DepartmentId equals dp.Id
                            select new GetEmployee
                            {
                                Department = dp.Name,
                                Email = em.Email,
                                Id = em.Id,
                                IsManager = em.IsManager,
                                Manager = em.Manager,
                                Name = em.Name,
                                Phone = em.Phone,
                                Salary = em.Salary
                            }).ToList();
                return Data;
            }
            catch (Exception ex)
            {
                var mes = ex;
                throw;
            }
           
        }
        public List<Employee> GetManagers()
        {
            return db.Employees.Where(m=>m.IsManager == true).ToList();
        }
    }
}

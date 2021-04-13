using Business.Manager.Interface;
using BusinessEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repository.Interface;
namespace Business.Manager
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepository repository;
        public DepartmentManager(IDepartmentRepository data)
        {
            repository = data;
        }
        public bool AddDepartment(Department dept)
        {
            return repository.AddDepartment(dept);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public Department GetDepartment(int id)
        {
            return repository.GetDepartment(id);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return repository.GetDepartments().ToList();
        }

        public bool UpdateDepartment(Department department)
        {
            return repository.UpdateDepartment(department);
        }
    }
}

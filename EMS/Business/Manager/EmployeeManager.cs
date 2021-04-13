using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Models;
using Business.Manager.Interface;
using Data.Repository.Interface;
namespace Business.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository repository;
        public EmployeeManager(IEmployeeRepository emp)
        {
            repository = emp;
        }
        public bool AddUpdateEmployee(Employee employee)
        {
            return repository.AddUpdateEmployee(employee);
        }

        public bool DeleteEmployee(int id)
        {
            return repository.DeleteEmployee(id);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return repository.GetDepartments();
        }

        public Employee GetEmployee(int id)
        {
            return repository.GetEmployee(id);
        }

        public IEnumerable<GetEmployee> GetEmployees()
        {
            try
            {
                return repository.GetEmployees();
            }
            catch (NullReferenceException ex)
            {
                var message = ex;
                throw;
            }
            
        }

        public List<Employee> GetManager()
        {
            return repository.GetManagers();
        }

        public List<Employee> GetManger()
        {
            return repository.GetManagers();
        }
    }
}

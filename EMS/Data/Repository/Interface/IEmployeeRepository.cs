using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Models;
namespace Data.Repository.Interface
{
    public interface IEmployeeRepository
    {
        bool AddUpdateEmployee(Employee employee);
        IEnumerable<GetEmployee> GetEmployees();
        Employee GetEmployee(int id);
        bool DeleteEmployee(int id);
        List<Employee> GetManagers();
        IEnumerable<Department> GetDepartments();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Models;
namespace Data.Repository.Interface
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartment(int id);
        bool AddDepartment(Department dept);
        bool UpdateDepartment(Department department);
        bool Delete(int id);
        
    }
}

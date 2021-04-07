using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace EmployeeCrud.Models
{
    public class EmployeeDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
         public EmployeeDBContext(DbContextOptions<EmployeeDBContext> dbContextOptions) : base(dbContextOptions) { }
         public System.Data.Entity.DbSet<Employee> Employee { get; set; }
    }   
}

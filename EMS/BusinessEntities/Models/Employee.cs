using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BusinessEntities.Models
{
    public partial class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
       
        public decimal Salary { get; set; }
        public bool IsManager { get; set; }
        public string Manager { get; set; }
        public decimal Phone { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Departments { get; set; }
    }
}

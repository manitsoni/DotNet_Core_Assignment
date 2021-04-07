using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCrud.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public decimal? Salary { get; set; }
        [Required]
        public bool? IsManager { get; set; }
        [Required]
        public string Manager { get; set; }
        [Required]
        public decimal? Phone { get; set; }
        [Required]
        public string Email { get; set; }

    }
}

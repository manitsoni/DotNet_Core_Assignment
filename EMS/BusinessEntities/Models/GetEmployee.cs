using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Models
{
    public class GetEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Salary { get; set; }
        public bool IsManager { get; set; }
        public string Manager { get; set; }
        public decimal Phone { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
    }
}

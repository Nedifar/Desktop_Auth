using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authtoriztion.Models
{
    public class EmployeeType
    {
        [Key]
        public int idEmployeeType { get; set; }
        public string name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Models
{
    public class EmployeeCreateDTO
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LasttName { get; set; }
        [Required, MaxLength(100)]
        public DateTime Created { get; set; }


    }
}

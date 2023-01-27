using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Models
{
    public class EmployeeUpdateDTO
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required, MaxLength(100)]
        public string Created { get; set; }
    }
}

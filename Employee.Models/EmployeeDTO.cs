using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Models
{
    public class EmployeeDTO
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter Employee firstname"), MaxLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter Employee lastname"), MaxLength(100)]
        public string LastName { get; set; }
        public DateTime? Created { get; set; }
    }
}

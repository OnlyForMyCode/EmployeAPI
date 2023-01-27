using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data.Entities
{
    public class Employe
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string Lastname { get; set; }
        public DateTime? Created { get; set;}
        public DateTime? LastUpdated { get; set; }

    }
}

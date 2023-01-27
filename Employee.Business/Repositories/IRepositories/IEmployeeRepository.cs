using Employee.Data.Entities;
using Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Business.Repositories.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDTO>> GetAllAsync();
        Task<EmployeeDTO> GetAsync(int id);
        Task<Employe> GetAsync(string fname, string lname, DateTime hdate);
        Task CreateAsync(EmployeeDTO employee);
        Task UpdateAsync(EmployeeDTO employee);
        Task<int> RemoveAsync(int id);
    }
}

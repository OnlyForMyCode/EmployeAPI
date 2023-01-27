using AutoMapper;
using Employee.Business.Repositories.IRepositories;
using Employee.Data;
using Employee.Data.Entities;
using Employee.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Employee.Business.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public EmployeeRepository(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task CreateAsync(EmployeeDTO objDTO)
        {
            var obj = mapper.Map<EmployeeDTO, Employe>(objDTO);
            db.Employees.Add(obj);
            await db.SaveChangesAsync();
        }
        public async Task<Employe> GetAsync(string fname, string lname, DateTime hdate)
        {
            return await db.Employees.FirstOrDefaultAsync(u => (u.FirstName.ToLower() == fname.ToLower()) && (u.Lastname.ToLower() == lname.ToLower()) && (u.Created == hdate));
        }
        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            var obj = await db.Employees.ToListAsync();
            return mapper.Map<IEnumerable<Employe>, IEnumerable<EmployeeDTO>>(obj);
        }
        public async Task<EmployeeDTO> GetAsync(int id)
        {
            var obj = await db.Employees.FirstOrDefaultAsync(u => u.Id == id);
            return mapper.Map<Employe,EmployeeDTO>(obj);
        }
        public async Task<int> RemoveAsync(int id)
        {
            var obj = await db.Employees.FirstOrDefaultAsync(u => u.Id == id);
            if(obj != null)
            {
                db.Employees.Remove(obj);
                return await db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task UpdateAsync(EmployeeDTO objDTO)
        {
            var objFromDb = await db.Employees.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
            if(objFromDb != null )
            {
                objFromDb.FirstName = objDTO.FirstName;
                objFromDb.Lastname = objDTO.LastName;
                objFromDb.Created = objDTO.Created;

                db.Employees.Update(objFromDb);
                await db.SaveChangesAsync();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Employee.Data.Entities;
using Employee.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Employee.Business.Mapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Employe, EmployeeDTO>().ReverseMap();
            CreateMap<Employe, EmployeeCreateDTO>().ReverseMap();
            CreateMap<Employe, EmployeeUpdateDTO>().ReverseMap();
            CreateMap<LocalUser, UserDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}

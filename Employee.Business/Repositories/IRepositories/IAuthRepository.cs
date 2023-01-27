using Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Business.Repositories.IRepositories
{
    public interface IAuthRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegisterationRequestDTO requestDTO);
    }
}

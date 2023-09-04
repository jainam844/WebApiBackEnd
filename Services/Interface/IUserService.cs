using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IUserService
    {
        Task<List<Users>> GetUsers();
        Task<int> InsertUser(Users user);
        Task<int> UpdateUser(Users user);
        Task<int> DeleteUser(int userId);
        Task<Users> GetUserById(int userId);
    }
}

using Dapper;
using Data.Data;
using Data.Entities;
using Services.Interface;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class LoginService : ILoginService
    {
        private readonly DapperContext _context;
        public LoginService(DapperContext context)
        {
            _context = context;

        }
        public async Task<Users?> LoggedUser( LoginViewModel loginViewModel)
        {
            string? query = $"SELECT * FROM Users where  Email='{loginViewModel.Email}' AND Password='{loginViewModel.Password}'";
            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<Users>(query);

                return users != null ? users.FirstOrDefault() : new Users();
            }
        }


    }

}

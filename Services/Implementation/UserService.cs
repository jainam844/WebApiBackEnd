using Dapper;
using Data.Data;
using Data.Entities;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly DapperContext _context;
        public UserService(DapperContext context)
        {
            _context = context;

        }
        public async Task<List<Users>> GetUsers()
        {
            string? query = "SELECT * FROM Users";
            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<Users>(query);
                return users.ToList();
            }
        }
        public async Task<Users> GetUserById(int userId)
        {
            string? query = "SELECT * FROM Users WHERE UserId = @UserId";

            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<Users>(query, new { UserId = userId });
                return user;
            }
        }

        public async Task<int> InsertUser(Users user)
        {
            string? query = $"EXEC [dbo].[User_Insert] @Action='INSERT', @FirstName={user.FirstName}, @LastName={user.LastName}, @Gender={user.Gender},@Department={user.Department},@DateOfBirth='{DateTime.Parse(user.Date_Of_Birth).ToString("dd-MM-yyyy")}',@Email='{user.Email}',@Password='{user.Password}'";
            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<int>(query);
                return users.FirstOrDefault();
            }
           
        }
        public async Task<int> UpdateUser(Users user)
        {
            string? query = $"EXEC[dbo].[User_Update] @Action='UPDATE',@UserId = {user.UserId}, @FirstName={user.FirstName}, @LastName={user.LastName}, @Gender={user.Gender},@Department={user.Department},@DateOfBirth='{user.Date_Of_Birth}',@Email='{user.Email}',@Password='{user.Password}'";
            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<int>(query);
                return users.FirstOrDefault();
            }
           
        }

        public async Task<int> DeleteUser(int userId)
        {
            string? query = $"EXEC [dbo].[User_Delete] @Action='DELETE', @UserId = {userId}";
            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<int>(query);
                return users.FirstOrDefault();
            }
 
        }
     
    }
}


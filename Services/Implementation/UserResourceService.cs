using Dapper;
using Data.Data;
using Data.Entities;
using Services.Interface;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class UserResourceService : IUserResource
    {

        private readonly DapperContext _context;
        public UserResourceService(DapperContext context)
        {
            _context = context;

        }
        public async Task<List<UserResource>> GetUserResourceResults()
        {
            string? query = $"EXEC User_Resources_Display";
            using (var connection = _context.CreateConnection())
            {
                var UserResource = await connection.QueryAsync<UserResource>(query);
                return UserResource.ToList();
            }
        }
        public async Task<List<UserResourceViewModel>> GetResourseByUserId(int userId)
        {
            string? query = $"Exec User_Resources_GetByUserId @UserId={userId}";

            using (var connection = _context.CreateConnection())
            {
                var UserResource = await connection.QueryAsync<UserResourceViewModel>(query);
                return UserResource.ToList();
            }
        }

        public async Task<UserActionResult> GetUserAction(int UserId, int ResourceId)
        {
            string? query = $"EXEC User_Resource_Add @UserId={UserId},@ResourceId={ResourceId}";
            using (var connection = _context.CreateConnection())
            {
                var UserAction = await connection.QueryFirstOrDefaultAsync<UserActionResult>(query);
                return UserAction;
            }
        }


        public async Task<UserActionResult> GetUserResourceDelete(int UserId, int ResourceId)
        {
            string? query = $"EXEC User_Resource_Delete @UserId={UserId},@ResourceId={ResourceId}";
            using (var connection = _context.CreateConnection())
            {
                var UserAction = await connection.QueryFirstOrDefaultAsync<UserActionResult>(query);
                return UserAction;
            }
        }

        public async Task<List<ResourceMaster>> GetResourcesList()
        {
            string? query = $"Select * from  ResourceMaster";
            using (var connection = _context.CreateConnection())
            {
                var UserResource = await connection.QueryAsync<ResourceMaster>(query);
                return UserResource.ToList();
            }

        }

        public async Task<UserActionResult> UpdateResourceForUser(int userId, int oldResourceId, int newResourceId)
        {
            string? query = $@" EXEC User_Resource_Update  {userId}, {oldResourceId},  {newResourceId};";

            using (var connection = _context.CreateConnection())
            {
                var UserResource = await connection.QueryFirstOrDefaultAsync<UserActionResult>(query);
                return UserResource;
            }
        }

    }
}

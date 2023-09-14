using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IUserResource
    {

        Task<List<UserResource>> GetUserResourceResults();
        Task<UserActionResult> GetUserAction(int UserId, int ResourceId);
        Task<UserActionResult> GetUserResourceDelete(int UserId, int ResourceId);
        Task<List<ResourceMaster>> GetResourcesList();
         Task<List<UserResourceViewModel>> GetResourseByUserId(int userId);

        Task<UserActionResult> UpdateResourceForUser(int userId, int oldResourceId, int newResourceId);
            }  
}

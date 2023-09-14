using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace FullStackWebAPI.Controllers
{
    [Route("api/userresource")]
    [ApiController]

    [Authorize]
    public class UserResourceController : ControllerBase
    {
        private readonly IUserResource userResourceService;

        public UserResourceController(IUserResource userResourceService)
        {
            this.userResourceService = userResourceService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetUserResource()
        {
            var userResources = await this.userResourceService.GetUserResourceResults();
            return Ok(userResources);
        }

        [HttpGet("get/{userId}")]
        public async Task<IActionResult> GetUserByResourceId(int userId)
        {
            try
            {
                var user = await this.userResourceService.GetResourseByUserId(userId);
                if (user.Count() != 0)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound(new { Message = "User not found." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "An error occurred while fetching the user.", Error = ex.Message });

            }
        }
        [HttpPost("addresourse")]
        public async Task<IActionResult> AddUpdateUserResource(int UserId ,int ResourceId)
        {
            var userResources = await this.userResourceService.GetUserAction(UserId, ResourceId);
            if (userResources.Status)
            {
                return Ok(userResources);
            }
            else
            {
                return NotFound(userResources.ReturnMessage);
            }
        }

        [HttpPost("updateresource")]
        public async Task<IActionResult> UpdateResourceForUser(int userId, int oldResourceId, int newResourceId)
        {
            var result = await this.userResourceService.UpdateResourceForUser(userId, oldResourceId, newResourceId);
            if (result.Status)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result.ReturnMessage);
            }
        
        }

        [HttpDelete("deleteresource")]
        public async Task<IActionResult> DeleteUserResource(int UserId,int ResourceId)
        {
            var userResources = await this.userResourceService.GetUserResourceDelete(UserId, ResourceId);
            if (userResources.Status)
            {
                return Ok(userResources);
            }
            else
            {
                return NotFound(userResources.ReturnMessage);
            }
        }
        [HttpGet("userresourceslist")]
        public async Task<IActionResult> ResourceList()
        {
            var resourceList = await this.userResourceService.GetResourcesList();
            return Ok(resourceList);
        }

    }
}

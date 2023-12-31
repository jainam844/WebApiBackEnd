﻿using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace FullStackWebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController (IUserService userService)
        {
            this.userService = userService;
        }
    

        [HttpGet("get")]
        public async  Task<IActionResult> GetUser()
         {
            var user = await this.userService.GetUsers();
            return Ok(user);    
        }
        [HttpGet("get/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            try
            {
                var user= await this.userService.GetUserById(userId);
                if (user != null)
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
        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] Users user)
        {
            try
            {
                int userId = await this.userService.InsertUser(user);
                return Ok(new { UserId = userId, Message = "User added successfully." });
            }
            catch (Exception ex)
            {
              
                return BadRequest(new { Message = "An error occurred while adding the user.", Error = ex.Message });
            }
        }  

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] Users user)
        {
            try
            {
                int userId = await this.userService.UpdateUser(user);
                return Ok(new { UserId = userId, Message = "User Updated  successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "An error occurred while adding the user.", Error = ex.Message });
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser(int userid)
        {
            try
            {
                int userId = await this.userService.DeleteUser(userid);
                return Ok(new { UserId = userId, Message = "User delete successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "An error occurred while adding the user.", Error = ex.Message });
            }
        }
    }
}

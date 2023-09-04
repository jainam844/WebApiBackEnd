using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Interface;
using Services.Models;

namespace FullStackWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        private readonly IConfiguration configuration;
        public LoginController(ILoginService loginService, IConfiguration configuration)
        {
            this.loginService = loginService;
            this.configuration = configuration;

        }
        [AllowAnonymous]
        

        [HttpPost]
        public async Task<JsonResult> Login(LoginViewModel loginViewModel)
        {
            try
            {
                Users? login = await this.loginService.LoggedUser(loginViewModel);

                if (login != null)
                {
                    var token = TokenManger.GenerateToken(login, this.configuration);

                    return new JsonResult(token);
                }

                return new JsonResult("Your email or password may be wrong.");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

    }
}

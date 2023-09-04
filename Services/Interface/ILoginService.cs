using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public  interface ILoginService
    {
        Task<Users> LoggedUser(LoginViewModel loginViewModel);
    }
}

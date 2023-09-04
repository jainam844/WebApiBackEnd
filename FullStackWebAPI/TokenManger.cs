using Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FullStackWebAPI
{
    public class TokenManger
    {
        public static string GenerateToken(Users user, IConfiguration configuration)
        {

            var key = configuration["Jwt:Key"];
            var Issuer = configuration["Jwt:Issuer"];
            var Audience = configuration["Jwt:Audience"];
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
           
            };
            var token = new JwtSecurityToken(Issuer,
                Audience,
                claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}

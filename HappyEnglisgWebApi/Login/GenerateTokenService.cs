using HappyEnglisgWebApi.Model;
using HappyEnglisgWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HappyEnglishWebApi.Login
{
    public class GenerateTokenService :ControllerBase, IGenerateTokenService
    {
        public IActionResult Login(LoginModel user)
        {
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }
            if (user.UserName == "string" && user.Password == "string")
            {
                var secretKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7088",
                    audience: "https://localhost:7088",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok(new AuthenticatedResponse { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}

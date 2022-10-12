using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApiJwt.Model;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase

    {
        //===================
        public static int cnt;

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel user)
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
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
               
                return Ok(new AuthenticatedResponse { Token = tokenString });
            }
            return Unauthorized();
        }



        //========================



        [HttpPost("test")]
        public IActionResult mymethod()
        {
            cnt = cnt + 1;

            if (cnt > 10 & cnt < 15)
            {
                return Unauthorized(cnt);
            }


            if (cnt % 2 == 0)
            {
                return Ok(cnt);
            }
            else
                return BadRequest(cnt);

            
           
            
        }


    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HappyEnglisgWebApi.Model;
using HappyEnglishWebApi.Login;
using HappyEnglisgWebApi.Repositories;

namespace HappyEnglisgWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IGenerateTokenService _generateTokenService;
        public AuthController(IGenerateTokenService generateTokenService)
        {
           _generateTokenService = generateTokenService;
        
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel user)
        {
           return _generateTokenService.Login(user);
        }

    }
}

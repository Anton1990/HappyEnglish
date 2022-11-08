using HappyEnglisgWebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace HappyEnglisgWebApi.Repositories
{
    public interface IGenerateTokenService
    {
        public IActionResult Login(LoginModel user);
                
    }
}

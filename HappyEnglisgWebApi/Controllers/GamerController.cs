using HappyEnglisgWebApi.Repositories;
using HappyEnglishWebApi.CustomExeption;
using HappyEnglishWebApi.Model;
using HappyEnglishWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Core;

namespace HappyEnglisgWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionFilter]
    public class GamerController : ControllerBase
    {
        private readonly IGamerRepostory _gamerRepository;
        public GamerController(IGamerRepostory gamerRepostory)
        {
            _gamerRepository = gamerRepostory;
        }

        [HttpGet]
        [Route("GetGamerById")]
        public async Task<IActionResult> GetGamerById(long id)
        {
            var gamer = await _gamerRepository.Get(id);
            return Ok(gamer);
        }

        [HttpGet]
        [Route("GetAllGamer")]
        public async Task<IActionResult> GetAllGamer()
        {
            return Ok(await _gamerRepository.GetAll());
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Gamer gamer)
        {
            return Ok(await _gamerRepository.Create(gamer));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Gamer gamer)
        {
            return Ok(await _gamerRepository.Update(id, gamer));
        }
         
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGamer(long id)
        {
            await _gamerRepository.Delete(id);
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public Task DeleteAll()
        {
            return _gamerRepository.DeleteAll();
        }

    }
} 



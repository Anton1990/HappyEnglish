using HappyEnglisgWebApi.Repositories;
using HappyEnglishWebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace HappyEnglisgWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamerControllerRepository : ControllerBase
    {
        private readonly IGamerRepostory _gamerRepository;
        private readonly ILogger<GamerControllerRepository> _logger;
        public GamerControllerRepository(IGamerRepostory gamerRepostory, ILogger<GamerControllerRepository> logger)
        {
            _gamerRepository = gamerRepostory;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetGamerById")]
        public async Task<IActionResult> GetGamerById(long id)
        {
            var gamer=await _gamerRepository.Get(id);
            if (gamer == null)
            {
                _logger.LogError($"Gamer with id: {id} doesn't exist in the database.");
                 return NotFound();
            }

            else
            {
                return  Ok(gamer);
            }
                    
        }

        [HttpGet]
        [Route("GetAllGamer")]
        public async Task<IEnumerable<Gamer>> GetAllGamer()
        {
            return await _gamerRepository.GetAll();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<Gamer> Create(Gamer gamer)
        {
            return await _gamerRepository.Create(gamer);
        }

        [HttpPut("{id}")]
        public  bool Update(long id, Gamer gamer)
        {
            return _gamerRepository.Update(id, gamer);
        }

        [HttpDelete("{id}")]
        public Task DeleteGamer(long id)
        {
            return _gamerRepository.Delete(id);
        }

        [HttpDelete]
        [Authorize]
        public Task DeleteAll()
        {
            return _gamerRepository.DeleteAll();
        }

    }
} 



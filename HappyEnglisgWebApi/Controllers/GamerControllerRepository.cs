using HappyEnglisgWebApi.Repositories;
using HappyEnglishWebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyEnglisgWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamerControllerRepository : ControllerBase
    {
        private readonly IGamerRepostory _gamerRepository;

        public GamerControllerRepository(IGamerRepostory gamerRepostory)
        {
            _gamerRepository = gamerRepostory;

        }

        [HttpGet]
        [Route("GetGamerById")]
        public async Task<Gamer> GetGamerById(long id)
        {
            return await _gamerRepository.Get(id);
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
        public bool Update(long id, Gamer gamer)
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



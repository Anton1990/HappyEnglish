using HappyEnglisgWebApi;
using HappyEnglisgWebApi.Model;
using HappyEnglisgWebApi.Repositories;
using Microsoft.AspNetCore.Http;
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
        
        public int GetGamerAll()
        {
            return _gamerRepository.value();
        }

    
    } 
}

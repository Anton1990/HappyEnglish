using HappyEnglishWebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HappyEnglisgWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamerController1 : ControllerBase
    {

        private readonly DBInteractor1 _context;

        public GamerController1(DBInteractor1 context)
        {
            _context = context;
        }


        [HttpGet]
        #region
        public async Task<ActionResult<IEnumerable<Gamer>>> GetGamerAll()
        {
            return await _context.Gamer.ToListAsync();
        }
        #endregion

    

        [HttpPost]
        #region
        public async Task<ActionResult<Gamer>> PostGamer(Gamer gamer)

        {
            //increment ID
            if (_context.Gamer.Count() == 0)
            {
                gamer.Id = 1;
            }
            else
                gamer.Id = _context.Gamer.OrderBy(x => x.Id).Last().Id + 1;

            _context.Gamer.Add(gamer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetGamer", new { id = gamer.Id }, gamer);
        }
        #endregion

     


    }
}

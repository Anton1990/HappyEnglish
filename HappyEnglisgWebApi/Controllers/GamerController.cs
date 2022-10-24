using HappyEnglisgWebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using HappyEnglishClassLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HappyEnglisgWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamerController : ControllerBase
    {

        private readonly DBInteractor _context;

        public GamerController(DBInteractor context)
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

        [HttpGet("{id}")]
        #region
        public async Task<ActionResult<Gamer>> GetGamer(long id)
        {
            var gamer = await _context.Gamer.FindAsync(id);

            if (gamer == null)
            {
                return NotFound();
            }

            return gamer;
        }
        #endregion

        [HttpPost]
        #region
        public async Task<ActionResult<Gamer>> PostGamer(Gamer gamer)

        {
            //increment ID
            if (_context.Gamer.Count()==0)
            {
                gamer.Id =1;
            }
            else
                gamer.Id = _context.Gamer.OrderBy(x => x.Id).Last().Id + 1;

            _context.Gamer.Add(gamer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetGamer", new { id = gamer.Id }, gamer);
        }
        #endregion
        
        [HttpDelete("{id}")]
        #region
        public async Task<IActionResult> DeleteGamer(long id)
        {
            var gamer = await _context.Gamer.FindAsync(id);
            if (gamer == null)
            {
                return NotFound();
            }

            _context.Gamer.Remove(gamer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        [HttpDelete, Authorize]
        [Route("DelAll/Jwt")]

        #region
        public async Task<IActionResult> DeleteAll()
        {                                             
            _context.Database.ExecuteSqlRaw("DELETE FROM Gamer");
            await _context.SaveChangesAsync();
            return NoContent();
        }
        #endregion


    }
}

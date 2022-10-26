using HappyEnglishWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HappyEnglisgWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {

        private readonly DBInteractor _context;

        private readonly HttpClient _client = new HttpClient(){Timeout = TimeSpan.FromSeconds(10)};

        public WordController(DBInteractor context)
        {
            _context = context;
            
        }

        [HttpGet]
        #region
        public async Task<ActionResult<IEnumerable<Word>>> GetWordAll()
        {
            return await _context.Word.ToListAsync();
        }
        #endregion

        [HttpPost]
        #region
        public async Task<ActionResult<Word>> PostWord()

        {
            Word word = new Word();
            //increment ID
            if (_context.Word.Count() == 0)
            {
                word.Id = 1;
            }
            else
            {
                word.Id = _context.Word.OrderBy(x => x.Id).Last().Id + 1;
            }

            
            word.Value = await getWordAsync();
            _context.Word.Add(word);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetWordAll", new { id = word.Id }, word);
        }
        #endregion

        private async Task<string> getWordAsync()
        {
            _client.Timeout = TimeSpan.FromSeconds(10);
            var content = await _client.GetStringAsync("https://random-word-api.herokuapp.com/word");
            return content.Trim(new Char[] { ' ', '[', ']', '"' });
        }
    }
}

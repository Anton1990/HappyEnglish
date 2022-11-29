using HappyEnglishWebApi.CustomExeption;
using HappyEnglishWebApi.DAL;
using HappyEnglishWebApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HappyEnglishWebApi.Repositories
{
    public class GamerRepository : IGamerRepostory
    {
        private readonly ApplicationDbContext _context;
        public GamerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        async Task<IEnumerable<Gamer>> IbaseRepository<Gamer>.GetAll()
        {
            return await _context.Gamer.ToListAsync();
        }
        async Task<Gamer> IbaseRepository<Gamer>.Create(Gamer gamer)
        {
             gamer.Id = 0;
            _context.Gamer.Add(gamer);
            await _context.SaveChangesAsync();
            return gamer;
        }
        async Task<Gamer> IbaseRepository<Gamer>.Get(long id)
        {   
            var gamer = await _context.Gamer.FindAsync(id);
            if (gamer == null) 
            {
                throw new InvalidGamerIdException(id);
            }
            return gamer; 
        }
        public async Task Delete(long id)
        {
                var gamer = await _context.Gamer.FindAsync(id);
                if (gamer == null)
                {
                 throw new InvalidGamerIdException(id);
                }
                _context.Gamer.Remove(gamer);
                await _context.SaveChangesAsync();
        }
        public async Task DeleteAll()
        {
            _context.Database.ExecuteSqlRaw("DELETE FROM Gamer");
            await _context.SaveChangesAsync();
            return;
        }
        async Task<Gamer> IbaseRepository<Gamer>.Update(long id, Gamer gamer)
        {
            if (id != gamer.Id || (!_context.Gamer.Any(e => e.Id == id)))
            {
                throw new InvalidGamerIdException(id);
            }
            _context.Entry(gamer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return gamer;
        }
    }
}

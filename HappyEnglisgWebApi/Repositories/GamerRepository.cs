using HappyEnglishWebApi.DAL;
using HappyEnglishWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace HappyEnglisgWebApi.Repositories
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
            if (_context.Gamer.Count() == 0)
            {
                gamer.Id = 1;
            }
            else
                gamer.Id = _context.Gamer.OrderBy(x => x.Id).Last().Id + 1;

            _context.Gamer.Add(gamer);
            await _context.SaveChangesAsync();
            return gamer;
        }

        public bool Update(long id, Gamer gamer)
        {
            if (id != gamer.Id)
            {
                return false;
            }
            _context.Entry(gamer).State = EntityState.Modified;
            try
            {
                _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Gamer.Any(e => e.Id == id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;

        }

        async Task<Gamer> IbaseRepository<Gamer>.Get(long id)
        {
            var gamer = await _context.Gamer.FindAsync(id);
            return gamer;
        }

        public async Task Delete(long id)
        {
            
                var gamer = await _context.Gamer.FindAsync(id);
                if (gamer == null)
                {
                return;
                }

                _context.Gamer.Remove(gamer);
                await _context.SaveChangesAsync();

                return;
       
        }

        public async Task DeleteAll()
        {
            _context.Database.ExecuteSqlRaw("DELETE FROM Gamer");
            await _context.SaveChangesAsync();
            return;
        }
    }
}

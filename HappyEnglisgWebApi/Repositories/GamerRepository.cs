using HappyEnglisgWebApi.Model;
using Microsoft.EntityFrameworkCore;
using HappyEnglishClassLibrary;

namespace HappyEnglisgWebApi.Repositories
{
    public class GamerRepository : IGamerRepostory
    {

        private readonly DBInteractor _context;
        private Class1 myclass = new Class1();
        public GamerRepository(DBInteractor context)
        {
            _context = context;

        }

        public int value()
        {
            
            return myclass.summ(1, 2);
           // return 22;

        }

        bool IbaseRepository<Gamer>.Create(Gamer entity)
        {
            throw new NotImplementedException();
        }

        bool IbaseRepository<Gamer>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Gamer IbaseRepository<Gamer>.Get(int id)
        {
            throw new NotImplementedException();
        }



     


        IEnumerable<Gamer> GetAll()
        {
            // throw new NotImplementedException();
            return _context.Gamer.ToList();

        }

        IEnumerable<Gamer> IbaseRepository<Gamer>.GetAll()
        {
            throw new NotImplementedException();
        }

        bool IbaseRepository<Gamer>.Update(Gamer entity)
        {
            throw new NotImplementedException();
        }
    }
}

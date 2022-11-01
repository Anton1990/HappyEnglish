using Microsoft.AspNetCore.Mvc;

namespace HappyEnglisgWebApi.Repositories
{
    public interface IbaseRepository<T>
    {
        Task<T> Create(T entity);
        bool Update(long id,T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(long id);
        Task Delete(long id);
        Task DeleteAll();
             
    }
}

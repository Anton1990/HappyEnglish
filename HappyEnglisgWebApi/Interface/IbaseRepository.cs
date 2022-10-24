namespace HappyEnglisgWebApi.Repositories
{
    public interface IbaseRepository<T>
    {
        bool Create(T entity);
        bool Update(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        bool Delete(int id);
        int value();

    }
}

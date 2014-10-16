using System.Linq;

namespace Howfar.Model.Interfaces
{
    public interface IGenericRepository<T>
    {
        T Add(T entity);
        T Remove(T entity);
        void Remove(long id);
        void Update(T entity);
        IQueryable<T> GetAll();
        T Get(object key);
        void Save();
    }
}

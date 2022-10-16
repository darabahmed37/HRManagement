using System.Linq.Expressions;

namespace HRManagementSystem.Repository.IRepository {

    public interface IRepository<T> where T : class {
        IEnumerable<T> GetAll();
        void Add(T obj);
        T? GetFirstOrDefault(Expression<Func<T, bool>> filter);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        void Update(T obj);
        void Save();

    }

}



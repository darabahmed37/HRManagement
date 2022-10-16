using System.Linq.Expressions;
using HRManagementSystem.Database;
using HRManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Repository {
    public class Repository<T> : IRepository<T> where T : class {

        private readonly HRDBContext _db;
        internal DbSet<T> DbSet;

        public Repository(HRDBContext db) {
            _db = db;
            this.DbSet = _db.Set<T>();
        }

        public IEnumerable<T> GetAll() {
            IQueryable<T> query = DbSet;
            return query.ToList();
        }

        public void Add(T obj) {
            DbSet.Add(obj);
        }

        public T? GetFirstOrDefault(Expression<Func<T, bool>> filter) {
            return DbSet.FirstOrDefault(filter);
        }

        public void Remove(T entity) {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity) {
            DbSet.RemoveRange(entity);
        }

        public void Update(T obj) {
            DbSet.Update(obj);
            Save();
        }

        public void Save() {
            _db.SaveChanges();
        }

    }
}

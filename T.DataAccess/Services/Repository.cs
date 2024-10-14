using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using T.DataAccess.Data;
using T.DataAccess.Services.Interfaces;

namespace T.DataAccess.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        readonly TechTrialContext _db;
        internal DbSet<T> dbSet;
        public Repository(TechTrialContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public virtual IQueryable<T> GetAll(bool asNoTracking = true)
        {
            if (asNoTracking)
                return _db.Set<T>().AsNoTracking();
            else
                return _db.Set<T>().AsQueryable();
        }
        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public virtual async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
            return await _db.Set<T>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        }
        public virtual async Task<T?> GetBySpecAsync<Spec>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public virtual async Task<ICollection<T>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await _db.Set<T>().ToListAsync(cancellationToken);
        }
        public virtual async Task<ICollection<T>> ListAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _db.Set<T>().Where(predicate).ToListAsync(cancellationToken);
        }

        public virtual T Add(T entity, CancellationToken cancellationToken = default)
        {
            _db.Set<T>().Add(entity);

            return entity;
        }
        public virtual void Update(T entity)
        {
            _db.Set<T>().Update(entity);
        }
        public virtual void Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
        }
    }
}

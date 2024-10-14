using System.Linq.Expressions;

namespace T.DataAccess.Services.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetBySpecAsync<Spec>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        IEnumerable<T> GetAll(string? includeProperties = null);
        Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;
        Task<ICollection<T>> ListAsync(CancellationToken cancellationToken = default);
        T Add(T entity, CancellationToken cancellationToken = default);

        void Update(T entity);
        void Remove(T item);
    }
}

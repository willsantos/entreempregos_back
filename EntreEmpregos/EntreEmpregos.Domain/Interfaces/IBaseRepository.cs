using System.Linq.Expressions;

namespace EntreEmpregos.Domain.Interfaces;

public interface IBaseRepository<T> where T: class
{
    Task<T> FindAsync(Guid? id);
    Task<T> FindAsync(Expression<Func<T, bool>> expression);
    Task<T> FindAsNoTrackingAsync(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> ListAsync();
    Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> expression);
    Task AddAsync(T item);
    Task RemoveAsync(Guid? id);
    Task EditAsync(T item);
}
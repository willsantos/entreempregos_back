using System.Linq.Expressions;
using EntreEmpregos.Domain.Interfaces;
using EntreEmpregos.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace EntreEmpregos.Repository.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<T> FindAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> FindAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(expression);
    }

    public async Task<T> FindAsNoTrackingAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
    }


    public async Task<IEnumerable<T>> ListAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().Where(expression).ToListAsync();
    }

    public async Task AddAsync(T item)
    {
        await _context.Set<T>().AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(T item)
    {
        _context.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task EditAsync(T item)
    {
        _context.Set<T>().Update(item);
        await _context.SaveChangesAsync();
    }
}

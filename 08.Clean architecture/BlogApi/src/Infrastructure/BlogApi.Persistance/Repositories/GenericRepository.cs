

using BlogApi.Application.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
namespace BlogApi.Infrastructure.Prersistance.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T: class
{
    private readonly BlogApiDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(BlogApiDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task<T> Get(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Exists(int id)
    {
        return await _dbSet.FindAsync(id) != null;
    }

    public async Task Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
} 
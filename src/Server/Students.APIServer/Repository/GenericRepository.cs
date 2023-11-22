using Microsoft.EntityFrameworkCore;
using Students.DBCore.Contexts;

namespace Students.APIServer.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    StudentContext _context;
    DbSet<TEntity> _dbSet;
 
    public GenericRepository(StudentContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
 
    public async Task<IEnumerable<TEntity>> Get()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }
         
    public async Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).AsQueryable().ToListAsync();
    }
    public async Task<TEntity> FindById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }
 
    public async Task<TEntity> Create(TEntity item)
    {
        _dbSet.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }
    public async Task<TEntity> Update(TEntity item)
    {
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return item;
    }
    public async Task Remove(TEntity item)
    {
        _dbSet.Remove(item);
        await _context.SaveChangesAsync();
    }
}
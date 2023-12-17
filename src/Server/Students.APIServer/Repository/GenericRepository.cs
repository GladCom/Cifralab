using Microsoft.EntityFrameworkCore;
using Students.DBCore.Contexts;

namespace Students.APIServer.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly StudentContext _context;
    private readonly DbSet<TEntity> _dbSet;
 
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
    public async Task<TEntity> Update(Guid Id, TEntity item)
    {
        var oldItem = await _dbSet.FindAsync(Id);
        if (oldItem == null)
        {
            return null;
        }
        item.GetType().GetProperty("Id")?.SetValue(item, Id);
        _context.Entry(oldItem).CurrentValues.SetValues(item);
        await _context.SaveChangesAsync();
        return item;
    }
    public async Task Remove(TEntity item)
    {
        _dbSet.Remove(item);
        await _context.SaveChangesAsync();
    }
}
using BFF.Core.Repository;
using BFF.Core.Data.Entities.BaseImp;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using BFF.Core.Data;

public class ODataRepository<T> : IODataRepository<T> where T : class,IEntity 
{
    private readonly DataContext _dataContext;
    private readonly DbSet<T> _dbSet;

    public ODataRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
        _dbSet = _dataContext.Set<T>();
    }

    public async Task<List<T>> GetAll(ODataQueryOptions<T> options)
    {
        var queryable = options.ApplyTo(_dbSet) as IQueryable<T>;
        return await queryable.ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Insert(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _dataContext.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        _dataContext.Entry(entity).State = EntityState.Modified;
        await _dataContext.SaveChangesAsync();
    }
    public async Task<List<T>> GetByIds(IEnumerable<int> ids)
    {
        var result = await _dbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
        return result;
    }
}

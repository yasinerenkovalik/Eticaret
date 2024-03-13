using Eticaret.Application.Repositories;
using Eticaret.Domain.Entities.Commen;
using Eticaret.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Eticaret.Persistance.Repositories;

public class WriteRepository<T>:IWriteRepository<T>  where T:BaseEntity
{
    readonly private EticaretContext _eticaretContext;

    public WriteRepository(EticaretContext eticaretContext)
    {
        _eticaretContext = eticaretContext;
    }

    public DbSet<T> Table => _eticaretContext.Set<T>();
    public async Task<bool> AddAsync(T entity)
    {
     EntityEntry<T> entityEntry= await Table.AddAsync(entity);
     return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRanceAsync(List<T> entity)
    {
        await Table.AddRangeAsync(entity);
        return true;
    }

    public bool Remove(T entity)
    {
       EntityEntry<T> entityEntry= Table.Remove(entity);
       return entityEntry.State == EntityState.Deleted;
    }

    public bool RemoveRange(List<T> entities)
    {
        Table.RemoveRange(entities);
        return true;
    }

    public async Task<bool> RemoveAsync(string id)
    {
       T model= await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
       return Remove(model);

    }

    public bool Update(T entity)
    {
      EntityEntry<T> entityEntry= Table.Update(entity);
      return entityEntry.State == EntityState.Modified;
    }

    public async Task<int> SaveAsync()
        => await _eticaretContext.SaveChangesAsync();
}
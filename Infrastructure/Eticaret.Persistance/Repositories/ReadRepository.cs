using System.Linq.Expressions;
using Eticaret.Application.Repositories;
using Eticaret.Domain.Entities.Commen;
using Eticaret.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Persistance.Repositories;

public class ReadRepository<T>:IReadRepository<T> where T:BaseEntity
{
    private readonly EticaretContext _eticaretContext;

    public ReadRepository(EticaretContext eticaretContext)
    {
        _eticaretContext = eticaretContext;
    }

    public DbSet<T> Table => _eticaretContext.Set<T>();

    public IQueryable<T> GetAll(bool tracking=true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
           query= query.AsNoTracking();
        return query;

    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.Where(method);
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = Table.AsNoTracking();
        return await query.FirstOrDefaultAsync(method);

    }

    public async  Task<T> GetByIdAsync(string id, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return await  query.FirstOrDefaultAsync(data=>data.Id==Guid.Parse(id));
    }
}
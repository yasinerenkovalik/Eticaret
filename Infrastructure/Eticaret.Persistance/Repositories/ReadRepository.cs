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

    public IQueryable<T> GetAll()
        => Table;

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        => Table.Where(method);

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        => await Table.FirstOrDefaultAsync(method);

    public async Task<T> GetByIdAsync(string id)
        => await Table.FindAsync(Guid.Parse(id));
}
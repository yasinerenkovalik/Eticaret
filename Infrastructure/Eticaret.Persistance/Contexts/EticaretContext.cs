using Eticaret.Domain.Entities;
using Eticaret.Domain.Entities.Commen;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Persistance.Contexts;

public class EticaretContext:DbContext
{
    public EticaretContext(DbContextOptions options):base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
    {
       var datas= ChangeTracker
            .Entries<BaseEntity>();
       foreach (var data in datas)
       {
           _ = data.State switch
           {
               EntityState.Added => data.Entity.CDateTime=DateTime.UtcNow,
               EntityState.Modified => data.Entity.UpdDateTime=DateTime.UtcNow,
               _=>DateTime.UtcNow
           };
       }
        return await base.SaveChangesAsync(cancellationToken);
    }
}
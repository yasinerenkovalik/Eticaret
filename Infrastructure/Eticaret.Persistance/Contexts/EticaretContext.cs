using Eticaret.Domain.Entities;
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
}
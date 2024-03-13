using System.Configuration;
using Microsoft.Extensions.Configuration;
using Eticaret.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Eticaret.Persistance;

public class DesingTimeDbContext:IDesignTimeDbContextFactory<EticaretContext>
{
    public EticaretContext CreateDbContext(string[] args)
    {
       
        DbContextOptionsBuilder<EticaretContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
        return new EticaretContext((dbContextOptionsBuilder.Options));
    }
}
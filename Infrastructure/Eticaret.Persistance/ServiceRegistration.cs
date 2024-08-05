using Eticaret.Application.Repositories;
using Eticaret.Persistance.Contexts;
using Eticaret.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Eticaret.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistanceService(this IServiceCollection serviceCollection)
    {
         serviceCollection.AddDbContext<EticaretContext>
        (options=>
            options.UseNpgsql
                (Configuration.ConnectionString));

        serviceCollection.AddScoped<IProductReadRepository, ProductReadrRepository>();
        serviceCollection.AddScoped<IProductWriteReposirtory, ProductWriteRepository>();
        serviceCollection.AddScoped<IOrderReadRepository, OrderReadRepository>();
        serviceCollection.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        serviceCollection.AddScoped<ICustomerReadRepository, CusotmerReadRepository>();
        serviceCollection.AddScoped<ICustomerWriterRepository, CustomerWriteRepository>();
        
       
    }
    
}
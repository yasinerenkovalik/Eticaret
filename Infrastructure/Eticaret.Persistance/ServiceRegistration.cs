using Eticaret.Application.Absract;
using Eticaret.Application.Repositories;
using Eticaret.Persistance.Concreates;
using Eticaret.Persistance.Contexts;
using Eticaret.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Eticaret.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistanceService(this IServiceCollection serviceCollection)
    {

        serviceCollection.AddScoped<IProductReadRepository, ProductReadrRepository>();
        serviceCollection.AddScoped<IProductWriteReposirtory, ProductWriteRepository>();
        serviceCollection.AddScoped<IOrderReadRepository, OrderReadRepository>();
        serviceCollection.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        serviceCollection.AddScoped<ICustomerReadRepository, CusotmerReadRepository>();
        serviceCollection.AddScoped<ICustomerWriterRepository, CustomerWriteRepository>();
        
        serviceCollection.AddDbContext<EticaretContext>
        (options=>
            options.UseNpgsql
                (Configuration.ConnectionString));
    }
    
}
using Eticaret.Application.Absract;
using Eticaret.Domain.Entities;

namespace Eticaret.Persistance.Concreates;

public class ProductService:IProductService
{
    public List<Product> GetProduct()
        => new()
        {
            new(){Name = "product1",Id = Guid.NewGuid(),Price = 100,Stock = 100},
            new(){Name = "product1",Id = Guid.NewGuid(),Price = 100,Stock = 100},
            new(){Name = "product1",Id = Guid.NewGuid(),Price = 100,Stock = 100},
            
        };
}
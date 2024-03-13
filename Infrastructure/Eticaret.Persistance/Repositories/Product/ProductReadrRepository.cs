using Eticaret.Application.Repositories;
using Eticaret.Domain.Entities;
using Eticaret.Persistance.Contexts;

namespace Eticaret.Persistance.Repositories;

public class ProductReadrRepository:ReadRepository<Product>,IProductReadRepository
{
    public ProductReadrRepository(EticaretContext eticaretContext) : base(eticaretContext)
    {
    }
}
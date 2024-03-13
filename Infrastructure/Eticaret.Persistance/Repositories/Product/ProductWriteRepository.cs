using Eticaret.Application.Repositories;
using Eticaret.Domain.Entities;
using Eticaret.Persistance.Contexts;

namespace Eticaret.Persistance.Repositories;

public class ProductWriteRepository:WriteRepository<Product>,IProductWriteReposirtory
{
    public ProductWriteRepository(EticaretContext eticaretContext) : base(eticaretContext)
    {
    }
}
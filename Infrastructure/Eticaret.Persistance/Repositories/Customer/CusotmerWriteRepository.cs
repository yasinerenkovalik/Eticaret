using Eticaret.Application.Repositories;
using Eticaret.Domain.Entities;
using Eticaret.Persistance.Contexts;

namespace Eticaret.Persistance.Repositories;

public class CusotmerReadRepository:ReadRepository<Customer>,ICustomerReadRepository
{
    public CusotmerReadRepository(EticaretContext eticaretContext) : base(eticaretContext)
    {
    }
}
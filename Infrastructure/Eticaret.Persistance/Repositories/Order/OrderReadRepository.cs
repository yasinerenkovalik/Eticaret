using Eticaret.Application.Repositories;
using Eticaret.Domain.Entities;
using Eticaret.Persistance.Contexts;

namespace Eticaret.Persistance.Repositories;

public class OrderReadRepository:ReadRepository<Order>,IOrderReadRepository
{
    public OrderReadRepository(EticaretContext eticaretContext) : base(eticaretContext)
    {
    }
}
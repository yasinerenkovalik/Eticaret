using Eticaret.Application.Repositories;
using Eticaret.Domain.Entities;
using Eticaret.Persistance.Contexts;

namespace Eticaret.Persistance.Repositories;

public class OrderWriteRepository:WriteRepository<Order>,IOrderWriteRepository
{
    public OrderWriteRepository(EticaretContext eticaretContext) : base(eticaretContext)
    {
    }
}
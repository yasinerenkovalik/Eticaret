using Eticaret.Application.Repositories;
using Eticaret.Domain.Entities;
using Eticaret.Persistance.Contexts;

namespace Eticaret.Persistance.Repositories;

public class CustomerWriteRepository:WriteRepository<Customer>,ICustomerWriterRepository
{
    public CustomerWriteRepository(EticaretContext eticaretContext) : base(eticaretContext)
    {
    }
}
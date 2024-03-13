using Eticaret.Domain.Entities;

namespace Eticaret.Application.Absract;

public interface IProductService
{
    List<Product> GetProduct();
}
using Eticaret.Domain.Entities.Commen;

namespace Eticaret.Domain.Entities;

public class Product:BaseEntity
{
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
    public ICollection<Order> Orders { get; set; }
}
using Eticaret.Domain.Entities.Commen;

namespace Eticaret.Domain.Entities;

public class Order:BaseEntity
{
    public Guid CustomerId { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }

    public ICollection<Product> Products { get; set; }
    public Customer Costumer { get; set; }
    
}
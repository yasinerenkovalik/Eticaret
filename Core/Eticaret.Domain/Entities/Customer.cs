using Eticaret.Domain.Entities.Commen;

namespace Eticaret.Domain.Entities;

public class Customer:BaseEntity
{
    public ICollection<Order> Orders { get; set; }
    public string Name { get; set; }
  
    
}
namespace Eticaret.Domain.Entities.Commen;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CDateTime { get; set; }
    public DateTime UpdDateTime { get; set; }
   
}
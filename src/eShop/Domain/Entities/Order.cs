using Domain.MoneyObject;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Order: Entity<Guid>
{
  public string? OrderNumber { get; set; }
  
  public Guid? CustomerId { get; set; }
  public virtual Customer? Customer { get; set; }
  public DateTime PaymentDate { get; set; }
  public string PaymentNumber { get; set; }
  public string PaymentType { get; set; }
  public virtual ICollection<OrderDetail> OrderDetails { get; set; }
 
}
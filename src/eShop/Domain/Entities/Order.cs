using Domain.MoneyObject;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Order: Entity<Guid>
{
  public string OrderNumber { get; set; }
  public virtual ICollection<OrderProduct>? OrderProducts { get; set; }
  public int Quantity { get; set; }
  public  Money Price { get; set; }
  public DateTime PaymentDate { get; set; }
  public string PaymentNumber { get; set; }
  public string PaymentType { get; set; }
  
  
}
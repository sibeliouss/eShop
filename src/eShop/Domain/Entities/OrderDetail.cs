using Domain.MoneyObject;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class OrderDetail: Entity<Guid>
{
    public Guid OrderId { get; set; }
    public virtual Order? Order { get; set; }
    public Guid ProductId { get; set; }
    public virtual Product? Product { get; set; }
    public int Quantity { get; set; }
    public Money Price { get; set; } = new(0, "₺");
}
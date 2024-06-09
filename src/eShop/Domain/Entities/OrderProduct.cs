using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class OrderProduct: Entity<Guid>
{
    public Guid OrderId { get; set; }
    public virtual Order? Order { get; set; }

    public Guid ProductId { get; set; }
    public virtual Product? Product { get; set; } 
}
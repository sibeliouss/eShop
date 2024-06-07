using Domain.MoneyObject;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Shopping : Entity<int>
{
   

    public Guid UserId { get; set; }
    public virtual User? User { get; set; }
    public int ProductId { get; set; }
    public virtual Product? Product { get; set; }
    public Money Price { get; set; }
    public int Quantity { get; set; }

}
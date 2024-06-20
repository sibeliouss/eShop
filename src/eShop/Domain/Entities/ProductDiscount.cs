using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProductDiscount: Entity<Guid>
{
    public Guid ProductId { get; set; }
    public virtual Product? Product { get; set; }
    public int DiscountPercentage { get; set; } = 0;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal DiscountPrice { get; set; } = 0;
}
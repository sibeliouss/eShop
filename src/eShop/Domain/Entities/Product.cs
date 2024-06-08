using Domain.MoneyObject;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Product: Entity<Guid>
{
   public string Name { get; set; } 
   public string Brand { get; set; }
   public string ImgUrl { get; set; }
   public string? Description { get; set; }
   public string Barcode { get; set; }
   public short Stock { get; set; }
   public Guid CategoryId { get; set; }
   public virtual Category? Category { get; set; }
   public Money Price { get; set; } = new(0, "₺");
   public Guid OrderId { get; set; }
   public virtual Order? Order { get; set; }
}
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Category : Entity<int>
{
   public string Name { get; set; } 
}
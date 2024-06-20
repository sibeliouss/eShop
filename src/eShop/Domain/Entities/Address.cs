using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Address : Entity<Guid>
{
    public Guid CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string? ZipCode { get; set; }
    public string ContactName { get; set; }
    public string Description { get; set; }
    
}
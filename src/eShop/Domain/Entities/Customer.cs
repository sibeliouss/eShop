using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Customer : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public Guid UserId { get; set; }
    public virtual User? User { get; set; }
}
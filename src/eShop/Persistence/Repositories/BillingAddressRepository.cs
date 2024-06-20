using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BillingAddressRepository : EfRepositoryBase<BillingAddress, Guid, BaseDbContext>, IBillingAddressRepository
{
    public BillingAddressRepository(BaseDbContext context) : base(context)
    {
    }
}
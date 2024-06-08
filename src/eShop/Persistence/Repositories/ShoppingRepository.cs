using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ShoppingRepository : EfRepositoryBase<Shopping, Guid, BaseDbContext>, IShoppingRepository
{
    public ShoppingRepository(BaseDbContext context) : base(context)
    {
    }
}
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OrderProductRepository : EfRepositoryBase<OrderProduct, Guid, BaseDbContext>, IOrderProductRepository
{
    public OrderProductRepository(BaseDbContext context) : base(context)
    {
    }
}
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OrderInformationRepository : EfRepositoryBase<OrderInformation, Guid, BaseDbContext>, IOrderInformationRepository
{
    public OrderInformationRepository(BaseDbContext context) : base(context)
    {
    }
}
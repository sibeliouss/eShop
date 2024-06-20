using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductDiscountRepository : EfRepositoryBase<ProductDiscount, Guid, BaseDbContext>, IProductDiscountRepository
{
    public ProductDiscountRepository(BaseDbContext context) : base(context)
    {
    }
}
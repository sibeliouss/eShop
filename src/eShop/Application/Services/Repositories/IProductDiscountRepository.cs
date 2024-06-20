using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductDiscountRepository : IAsyncRepository<ProductDiscount, Guid>, IRepository<ProductDiscount, Guid>
{
}
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOrderProductRepository : IAsyncRepository<OrderProduct, Guid>, IRepository<OrderProduct, Guid>
{
}
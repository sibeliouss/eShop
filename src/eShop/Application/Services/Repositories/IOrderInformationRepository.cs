using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOrderInformationRepository : IAsyncRepository<OrderInformation, Guid>, IRepository<OrderInformation, Guid>
{
}
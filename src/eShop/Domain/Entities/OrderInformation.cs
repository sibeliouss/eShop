using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class OrderInformation : Entity<Guid>
{
    public string OrderNumber { get; set; }
    public OrderStatusEnum? OrderStatusEnum { get; set; }  
    public DateTime StatusDate { get; set; }  
}
using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class OrderStatus : Entity<int>
{
    public string OrderNumber { get; set; }
    public OrderStatues Status { get; set; }
    public DateTime StatusDate { get; set; }
}
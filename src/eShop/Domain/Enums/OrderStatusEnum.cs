namespace Domain.Enums;

public enum OrderStatusEnum
{
    AwaitingApproval = 1, // Onay bekliyor
    BeingPrepared = 2, // Hazırlanıyor
    InTransit = 3, // Dağıtımda - Yolda
    Delivered = 4, 
    Rejected = 5, 
    Returned = 6
}
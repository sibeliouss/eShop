namespace Domain.MoneyObject;


public sealed record Money(decimal Value, string Currency)
{
    public decimal Value { get; private init; } = Value;
    public string Currency { get; private init; } = Currency;
}



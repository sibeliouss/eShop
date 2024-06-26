namespace Domain.MoneyObject;

public record Money(decimal Value, string Currency)
{
    public decimal Value { get; private init; } = Value;
    public string Currency { get; private init; } = Currency;
};
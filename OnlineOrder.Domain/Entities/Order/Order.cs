using OnlineOrder.Domain.Entities.Order.Enums;
using OnlineOrder.Domain.Helpers.Models;

namespace OnlineOrder.Domain.Entities.Order;

public class Order : IAggregateRoot
{
    public long? Id { get; set; }

    public string? Name { get; set; }

    public double TotalPrice { get; set; }

    public IEnumerable<OrderLine>? OrderLines { get; set; }

    public CurrencyEnum Currency { get; set; }

    public static Order Create(string? name, double? totalPrice, IEnumerable<OrderLine>? orderLines,
        CurrencyEnum? currency)
    {
        return new Order
        {
            Name = name,
            TotalPrice = totalPrice ?? 0.0,
            OrderLines = orderLines,
            Currency = currency ?? CurrencyEnum.GBP
        };
    }
}
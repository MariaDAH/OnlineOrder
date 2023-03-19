using OnlineOrder.Domain.Entities.Order.Enums;

namespace OnlineOrder.Domain.Entities.Order;

public class Transaction
{
    public long? Id { get; set; }
    
    public TransactionTypeEnum Type { get; set; }

    public TransactionStatus Status { get; set; }

    public double Amount { get; set; }
}
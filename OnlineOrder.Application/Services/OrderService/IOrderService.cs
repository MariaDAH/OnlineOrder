using OnlineOrder.Domain.Entities.Order;

namespace OnlineOrder.Application.Services.OrderService;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrdersAsync(CancellationToken cancellationToken = default);

    Task<Order?> GetOrderByIdAsync(long id, CancellationToken cancellationToken = default);

    Task CreateOrderAsync(Order order, CancellationToken cancellationToken = default);
    
    Task<long?> UpdateOrderAsync(Order order, CancellationToken cancellationToken = default);

    Task<long?> DeleteOrderAsync(long id, CancellationToken cancellationToken = default);
}
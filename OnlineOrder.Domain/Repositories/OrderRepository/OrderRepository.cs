using OnlineOrder.Domain.DAOs;
using OnlineOrder.Domain.Entities.Order;

namespace OnlineOrder.Domain.Repositories.OrderRepository;

public class OrderRepository: GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context) : base(context)
    {
            
    }

    public ApplicationDbContext OnlineOrderDao
    {
        get { return Context as ApplicationDbContext; }
    }
}
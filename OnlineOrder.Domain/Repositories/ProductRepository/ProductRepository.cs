using OnlineOrder.Domain.DAOs;
using OnlineOrder.Domain.Entities.Product;

namespace OnlineOrder.Domain.Repositories.ProductRepository;

public class ProductRepository: GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
            
    }
    
    public ApplicationDbContext OnlineOrderDao
    {
        get { return Context as ApplicationDbContext; }
    }
}
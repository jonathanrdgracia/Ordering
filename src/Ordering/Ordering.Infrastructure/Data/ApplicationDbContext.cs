using Ordering.Application.Data;
using Ordering.Domain.Models;

namespace Ordering.Infrastructure.Data
{
    public class ApplicationDbContext: IApplicationDbContext
    {
        private readonly DbContext _context;

        public ApplicationDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            _context = new DbContext(connectionString);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task<List<Order>> GetOrdersAsync() => _context.GetOrdersAsync();
     

        public Task<int> CreateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        Task<int> IApplicationDbContext.UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        Task<int> IApplicationDbContext.DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddOrderAsync(Order order)
        {
            await  _context.AddOrderAsync(order);
        }

        Task<IEnumerable<Order>> IApplicationDbContext.GetOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

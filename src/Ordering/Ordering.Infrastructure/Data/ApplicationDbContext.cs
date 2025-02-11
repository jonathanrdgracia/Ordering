using Ordering.Application.Data;
using Ordering.Application.Dtos;
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
        public async Task AddOrderAsync(Order order)
        {
            await  _context.AddOrderAsync(order);
        }

        public Task<List<Order>> GetOrdersAsync() => _context.GetOrdersAsync();


        public Task<Order> GetOrdersByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.GetOrderByIdAsync(id);
        }

        Task<Order> IApplicationDbContext.CreateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOrderAsync(OrderDto Order)
        {
            await _context.UpdateOrderAsync(Order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _context.DeleteOrderAsync(id);
        }
    }
}

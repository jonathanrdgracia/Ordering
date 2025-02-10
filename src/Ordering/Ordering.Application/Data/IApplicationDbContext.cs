using Ordering.Application.Dtos;
using Ordering.Domain.Models;

namespace Ordering.Application.Data
{
    public interface IApplicationDbContext
    {
        Task AddOrderAsync(Order order);
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrdersByIdAsync(int id); 
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> CreateOrderAsync(Order order);
        Task UpdateOrderAsync(OrderDto order);
        Task DeleteOrderAsync(int id);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

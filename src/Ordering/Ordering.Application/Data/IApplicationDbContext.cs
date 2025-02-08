using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Models;

namespace Ordering.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Order> Orders { get; }

        //Task<IEnumerable<Orders>> GetOrdersAsync();
        //Task<Orders> GetOrderByIdAsync(int id);
        //Task<int> CreateOrderAsync(Orders order);
        //Task<int> UpdateOrderAsync(Orders order);
        //Task<int> DeleteOrderAsync(int id);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}

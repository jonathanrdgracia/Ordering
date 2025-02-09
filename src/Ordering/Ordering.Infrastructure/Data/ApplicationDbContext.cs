using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Dtos;
using Ordering.Domain.Models;

namespace Ordering.Infrastructure.Data
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}


        public DbSet<Order> Orders => Set<Order>();

        public Task<int> CreateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>().Property(c => c.CustomerName).IsRequired();
            builder.Entity<Order>().Property(c => c.OrderDate).IsRequired();
            builder.Entity<Order>().Property(c => c.TotalAmount).IsRequired();

            builder.Entity<Order>().ToTable("Orders", "Ordering");


            base.OnModelCreating(builder);
        }
    }
}

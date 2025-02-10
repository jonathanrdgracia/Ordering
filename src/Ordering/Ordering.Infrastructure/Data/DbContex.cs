using Ordering.Application.Dtos;
using Ordering.Domain.Enums;
using Ordering.Domain.Models;


namespace Ordering.Infrastructure.Data
{
    public class DbContext
    {
        private readonly string _connectionString;

        public DbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await Task.FromResult(0);
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            var orders = new List<Order>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT Id, CustomerName, TotalAmount, Status, OrderDate FROM [Ordering].[Orders]", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync()) // Cambiado de 'if' a 'while' para múltiples registros
                    {
                        var order = new Order
                        {
                            Id = reader.GetInt32(0),
                            CustomerName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            TotalAmount = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2),
                            Status = reader.GetBoolean(3) ? OrderStatus.Active : OrderStatus.Deleted,
                            OrderDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4)
                        };

                        orders.Add(order);
                    }
                }
            }

            return orders;
        }


        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT Id, CustomerName, TotalAmount, Status, OrderDate  FROM [Ordering].[Orders] WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Order
                        {
                            Id = reader.GetInt32(0),
                            CustomerName = reader.GetString(1),
                            TotalAmount = reader.GetDecimal(2),
                            Status = reader.GetBoolean(3) ? OrderStatus.Active : OrderStatus.Deleted,
                            OrderDate = reader.GetDateTime(4)
                        };
                    }
                }
            }
            return null;
        }



        public async Task AddOrderAsync(Order Order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("INSERT INTO [Ordering].[Orders] " +
                    " ([CustomerName],[OrderDate],[TotalAmount],[Status]) VALUES (@CustomerName,@OrderDate,@TotalAmount,@Status)", connection);
                command.Parameters.AddWithValue("@CustomerName", Order.CustomerName);
                command.Parameters.AddWithValue("@OrderDate", DateTime.UtcNow);
                command.Parameters.AddWithValue("@TotalAmount", Order.TotalAmount);
                command.Parameters.AddWithValue("@Status", Order.Status);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateOrderAsync(OrderDto Order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("UPDATE [Ordering].[Orders] SET CustomerName = @CustomerName,Status = @Status, TotalAmount = @TotalAmount WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@CustomerName", Order.CustomerName);
                command.Parameters.AddWithValue("@Id", Order.Id);
                command.Parameters.AddWithValue("@TotalAmount", Order.TotalAmount);
                command.Parameters.AddWithValue("@Status", Order.Status);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteOrderAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("DELETE FROM Orders WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
    public static class SqlDataReaderExtensions
    {
        public static OrderStatus GetOrderStatus(this SqlDataReader reader, string columnName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(columnName)))
            {
                bool status = reader.GetBoolean(reader.GetOrdinal(columnName));
                return status ? OrderStatus.Active : OrderStatus.Deleted;
            }
            return OrderStatus.Deleted; 
        }
    }

}

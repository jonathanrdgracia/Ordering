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
                var command = new SqlCommand("SELECT Id, Description, Amount FROM Orders", connection);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        orders.Add(new Order
                        {
                            
                            CustomerName = reader.GetString(1),
                            TotalAmount = reader.GetDecimal(2)
                        });
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
                var command = new SqlCommand("SELECT Id, Description, Amount FROM Orders WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Order
                        {
                            CustomerName = reader.GetString(1),
                            TotalAmount = reader.GetDecimal(2)
                        };
                    }
                }
            }
            return null;
        }

        public async Task AddOrderAsync(Order order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("INSERT INTO [Ordering].[Orders] " +
                    " ([CustomerName],[OrderDate],[TotalAmount],[Status]) VALUES (@CustomerName,@OrderDate,@TotalAmount,@Status)", connection);
                command.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                command.Parameters.AddWithValue("@OrderDate", DateTime.UtcNow);
                command.Parameters.AddWithValue("@TotalAmount", 33.4);
                command.Parameters.AddWithValue("@Status", order.Status);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateOrderAsync(Order order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("UPDATE Orders SET Description = @Description, Amount = @Amount WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Description", order.CustomerName);
                command.Parameters.AddWithValue("@Amount", order.TotalAmount);
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

}

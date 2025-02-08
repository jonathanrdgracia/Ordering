using Microsoft.EntityFrameworkCore;
using Ordering.Infrastructure.Data;

namespace Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DataBase");

            services.AddDbContext<ApplicationDbContext>(options=>
            options.UseSqlServer(connectionString));

            // Add services to the container.
            //services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            //services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            //services.AddDbContext<ApplicationDbContext>((sp, options) =>
            //{
            //    options.Add Interceptors(sp.GetServices<ISaveChangesInterceptor>());
            //    options.UseSqlServer(connectionString);
            //});
            //services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            return services;
                        
            
        }
    }
}

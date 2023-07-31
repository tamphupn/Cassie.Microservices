using CustomerService.Persistence;
using Microsoft.EntityFrameworkCore;
using Cassie.SharedInfrastructure.Domains;
using CustomerService.Domain.IRepositories;
using CustomerService.Persistence.Repositories;

namespace CustomerService.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
			services.Configure<RouteOptions>(x => x.LowercaseUrls = true);
			services.AddAutoMapper(typeof(Program));
			services.AddCustomerDbContext(configuration);
			services.AddCustomBusinessService();
			return services;
        }

		private static void AddCustomerDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnectionString");
			services.AddDbContext<CustomerDbContext>(opt => opt.UseNpgsql(connectionString));
		}

		private static void AddCustomBusinessService(this IServiceCollection services)
		{
			services.AddRepositoryAndUow();
			services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
	}
}
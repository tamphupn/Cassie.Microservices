using System;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using ProductService.Persistence;

namespace ProductService.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddControllers();
			services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
			services.AddProductDbContext(configuration);
			return services;
		}

		public static IServiceCollection AddProductDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnectionString");
			var builder = new MySqlConnectionStringBuilder(connectionString);

			services.AddDbContext<ProductDbContext>(x => x.UseMySql(builder.ConnectionString, ServerVersion.AutoDetect(builder.ConnectionString), e =>
			{
				e.MigrationsAssembly("Product.API");
				e.SchemaBehavior(Pomelo.EntityFrameworkCore.MySql.Infrastructure.MySqlSchemaBehavior.Ignore);
			}));

			return services;
		}
	}
}


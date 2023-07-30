using System;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using ProductService.Persistence;
using Cassie.SharedInfrastructure.Domains;
using ProductService.Persistence.Repositories;
using ProductService.Domain.IRepositories;

namespace ProductService.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
			services.AddSwaggerGen();
			services.AddProductDbContext(configuration);
			services.AddBusinessService();
            services.AddLogging();
            services.AddCustomMiddleWare();
			return services;
		}

		private static IServiceCollection AddProductDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnectionString");
			var builder = new MySqlConnectionStringBuilder(connectionString);

			services.AddDbContext<ProductDbContext>(x => x.UseMySql(builder.ConnectionString, ServerVersion.AutoDetect(builder.ConnectionString), e =>
			{
				e.MigrationsAssembly("ProductService");
				e.SchemaBehavior(Pomelo.EntityFrameworkCore.MySql.Infrastructure.MySqlSchemaBehavior.Ignore);
			}));

			return services;
		}

		private static void AddBusinessService(this IServiceCollection services)
		{
			services.AddRepositoryAndUow();
			services.AddTransient<ICatalogProductRepository, CatalogProductRepository>();
        }

		private static void AddCustomMiddleWare(this IServiceCollection services)
		{

		}
	}
}


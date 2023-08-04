using Cassie.SharedApplication;

namespace BasketService.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
			services.AddSwaggerGen();
			services.AddBasketDbContext(configuration);
            services.AddLogging();
            services.AddAutoMapper(typeof(Program));
            services.AddSharedApplicationServices();

            return services;
		}

		private static IServiceCollection AddBasketDbContext(this IServiceCollection services, IConfiguration configuration)
		{
            var redisConnectionString = configuration.GetSection("CacheSettings:ConnectionString").Value;
            if (string.IsNullOrEmpty(redisConnectionString))
                throw new ArgumentNullException("Redis Connection string is not configured.");

            //Redis Configuration
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConnectionString;
            });

            return services;
		}
	}
}


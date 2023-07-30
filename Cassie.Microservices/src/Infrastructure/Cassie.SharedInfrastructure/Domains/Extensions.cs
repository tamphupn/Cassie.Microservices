using Cassie.Contracts.Domains.Repositories;
using Cassie.SharedInfrastructure.Domains.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cassie.SharedInfrastructure.Domains
{
	public static class Extensions
	{
		public static IServiceCollection AddRepositoryAndUow(this IServiceCollection services)
		{
            services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddTransient(typeof(IRepositoryBase<,,>), typeof(RepositoryBase<,,>));
			return services;
        }
	}
}


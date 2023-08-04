using System;
using Cassie.Contracts.Applications;
using Cassie.Contracts.Domains.Repositories;
using Cassie.SharedApplication.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cassie.SharedApplication
{
    public static class SharedApplicationExtensions
    {
        public static IServiceCollection AddSharedApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ICassieSerializeService, CassieSerializeService>();
            return services;
        }
    }
}


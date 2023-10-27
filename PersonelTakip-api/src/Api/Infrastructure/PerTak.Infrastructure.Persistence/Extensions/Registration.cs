using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PerTak.Infrastructure.Persistence.Context;

namespace PerTak.Infrastructure.Persistence.Extensions;

public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PerTakDbContext>(conf =>
        {
            var connStr = configuration["PerTakDbConnectionString"].ToString();
            conf.UseNpgsql(connStr, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        });

        return services;
    }
}


using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PerTak.Api.Application.Interfaces.Repositories;
using PerTak.Infrastructure.Persistence.Context;
using PerTak.Infrastructure.Persistence.Repositories;

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

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWorkRepository, WorkRepository>();
        services.AddScoped<IDepartmenRepository, DepartmenRepository>();

        return services;
    }
}


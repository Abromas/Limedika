﻿using Limedika.Services.Interfaces;

namespace Limedika.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<ILogService, LogService>();
        services.AddHttpClient<IPostCodeService, PostCodeService>();

        return services;
    }
}

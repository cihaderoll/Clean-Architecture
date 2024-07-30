using CleanArchitectrure.Application.Interface.Infrastructure;
using CleanArchitectrure.Domain.Commands;
using CleanArchitectrure.Infrastructure.Consumers.Commands;
using CleanArchitectrure.Infrastructure.Redis;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectrure.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer(typeof(ValidateUserConsumer));

                //TODO configurasyonlar configden gelecek
                x.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("localhost", "/", c =>
                    {
                        c.Username("guest");
                        c.Password("guest");
                    });
                    cfg.ConfigureEndpoints(ctx);
                });
            });

            //Automatically registered
            //services.AddMassTransitHostedService();

            services.AddTransient<IRedisClient, RedisClient>();

            return services;
        }
    }
}

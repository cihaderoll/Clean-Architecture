using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Persistence.Contexts;
using CleanArchitectrure.Persistence.Repositories;
using CleanArchitectrure.Persistence.Repositories.Cached;
using CleanArchitectrure.Persistence.Repositories.NonCached;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace CleanArchitectrure.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("NorthwindConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddKeyedScoped<ICustomerRepository, CachedCustomerRepository>("CachedCustomerRepo");
            services.AddKeyedScoped<ICustomerRepository, CustomerRepository>("CustomerRepo");

            return services;
        }
    }
}

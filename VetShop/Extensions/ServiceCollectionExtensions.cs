using VetShop.Infrastructure.Data;
using VetShop.Infrastructure.Data.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using VetShop.Core.Implementations;
using VetShop.Core.Interfaces;
using NuGet.Protocol.Core.Types;

namespace VetShop.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IBrandService, BrandService>();

            services.AddMvc(options =>
                options
                .Filters
                .Add(new AutoValidateAntiforgeryTokenAttribute()));

            services.AddResponseCompression();

            return services;
        }

        public static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<VetShopDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
    
}

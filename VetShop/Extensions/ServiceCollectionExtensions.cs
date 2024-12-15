using VetShop.Infrastructure.Data;
using VetShop.Infrastructure.Data.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using VetShop.Core.Implementations;
using VetShop.Core.Interfaces;
using NuGet.Protocol.Core.Types;
using VetShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace VetShop.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ISavedProductService, SavedProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IVeterinaryService, VeterinaryService>();
            services.AddScoped<IAppointmentService, AppointmentService>();

            services.AddMvc(options =>
                options
                .Filters
                .Add(new AutoValidateAntiforgeryTokenAttribute()));

            services.AddResponseCompression();

            return services;
        }

        public static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<VetShopDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 5;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<VetShopDbContext>();

            return services;
        }
    }
    
}

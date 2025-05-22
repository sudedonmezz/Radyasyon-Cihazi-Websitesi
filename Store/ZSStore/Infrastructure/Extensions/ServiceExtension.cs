using Microsoft.EntityFrameworkCore;
using Repositories;
using Microsoft.AspNetCore.Http;
using Repositories.Contracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Services;
using Entities.Models;
using ZSStore.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ZSStore.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("sqlconnection"),
                    b => b.MigrationsAssembly("ZSStore"));

                    options.EnableSensitiveDataLogging(true); //hassas bilgileri loglara yansıtmak icin
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser,IdentityRole>(options=>
            {
                    options.SignIn.RequireConfirmedAccount=false;
                    options.User.RequireUniqueEmail=true;
                    options.Password.RequireUppercase=false;
                    options.Password.RequireLowercase=false;
                    options.Password.RequireDigit=false;
                    options.Password.RequiredLength=6;
            })
            .AddEntityFrameworkStores<RepositoryContext>();
        }

        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.Name = "ZSStore.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(c=>SessionCart.GetCart(c)); 
        }
        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ISupportMessageRepository, SupportMessageRepository>();
            services.AddScoped<IProductAnalysisRepository, ProductAnalysisRepository>();
            services.AddScoped<IContactMessageRepository, ContactMessageRepository>();


        }

        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<ISupportMessageService, SupportMessageManager>();
            services.AddScoped<IProductAnalysisService, ProductAnalysisManager>();
            services.AddScoped<IContactMessageService, ContactMessageManager>();
        }

        public static void ConfigureApplicationCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(op=>
            {
                op.LoginPath=new PathString("/Account/Login");
                op.ReturnUrlParameter=CookieAuthenticationDefaults.ReturnUrlParameter;
                op.ExpireTimeSpan=TimeSpan.FromMinutes(10);
                op.AccessDeniedPath= new PathString("/Account/AccessDenied");
            }
            
            );
        }

        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options=>
            {
                options.LowercaseUrls=true;
                options.AppendTrailingSlash=true;
            });
        }
    }
}

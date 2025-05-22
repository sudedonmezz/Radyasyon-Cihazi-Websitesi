using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ZSStore.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureLocalization(this WebApplication app )
        {
                app.UseRequestLocalization(options=>
                {
                    options.AddSupportedCultures("tr-TR")
                    .AddSupportedUICultures("tr-TR")
                    .SetDefaultCulture("tr-TR");
                }
                
                );
        }
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser="Admin";
            const string adminPassword="Admin+123456";

            UserManager<IdentityUser> userManager= app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();

            RoleManager<IdentityRole> roleManager=app
            .ApplicationServices
            .CreateAsyncScope()
            .ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

            IdentityUser user= await userManager.FindByNameAsync(adminUser);

            if(user is null)
            {
                user=new IdentityUser()
                {
                    Email="donmezsude41@gmail.com",
                    PhoneNumber="5555555555",
                    UserName=adminUser,
                    
                };

                var result=await userManager.CreateAsync(user,adminPassword);
                if(!result.Succeeded)
                throw new Exception("admin user oluşturulamadı.");

                var roleResult=await userManager.AddToRolesAsync(user,
                roleManager
                .Roles
                .Select(r=>r.Name)
                .ToList()
                );

                if(!roleResult.Succeeded)
                throw new Exception("sistemde admin rolü tanımlanmasında hata var.");
            }
        }
    }
}
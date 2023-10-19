using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EmployeeRegister.Core.Repositories;
using EmployeeRegister.Data;
/*namespace EmployeeRegister { 

public class Program
{
public static async Task Main(string[] args)
{*/
var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

             AddScoped();
            builder.Services.AddDbContext<EmployeeMasterContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn")));
            builder.Services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<EmployeeMasterContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); 

            app.UseAuthorization();
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "NTPC Employee" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }



            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string email = "ankitanand3456@gmail.com";
                string password = "Ankit@1234";

                if(await userManager.FindByEmailAsync(email)==null)
                {
                    var user = new IdentityUser();
                    user.Email = email;
                    user.UserName = email;

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user,"Admin");
                }
            }
            app.Run();


              void AddScoped()
          {
              builder.Services.AddScoped<IUserRepository,UserRepository>();
               builder.Services.AddScoped<IRoleRepository, RoleRepository>();

                   builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            }
/* }
}

}
,
         sqlServerOptionsAction:sqlOptions=>
     {
         sqlOptions.EnableRetryOnFailure(
             maxRetryCount: 10,
             maxRetryDelay: TimeSpan.FromSeconds(5),
             errorNumbersToAdd: null); 
     })*/
using CinemaApp.DAL.Data;
using CinemaApp.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Services
{
    public class SeedService
    {
        public static async Task SeedDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CinemaDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

            try
            {
                logger.LogInformation("Ensure the database is created.");
                await context.Database.EnsureCreatedAsync();

                logger.LogInformation("Seeding roles.");
                await AddRoleAsync(roleManager, "Admin");
                await AddRoleAsync(roleManager, "User");

                logger.LogInformation("Seeding admin user.");
                var adminEmail = "admin@codehub.com";

                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    //var _passwordHasher = new PasswordHasher<User>();
                    var adminUser = new User()
                    {
                        //Id = Guid.NewGuid().ToString(), //Ще подумаю чи всовувати
                        FullName = "Comand Number Seventeen",
                        Age = 35,                              //Додав Вік
                        UserName = adminEmail,
                        NormalizedUserName = adminEmail.ToUpper(),
                        Email = adminEmail,
                        NormalizedEmail = adminEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        RegistrationDate = DateTime.UtcNow // Дата реєстрації
                    };
                    var result = await userManager.CreateAsync(adminUser, "Admin@123");
                    if (result.Succeeded)
                    {
                        logger.LogInformation("Assigning Admin role to the admin user");
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                    /*
                    // Хешуємо пароль
                    adminUser.PasswordHash = _passwordHasher.HashPassword(adminUser, "Admin@123");

                    var result = await userManager.CreateAsync(adminUser);
                    if (result.Succeeded)
                    {
                        logger.LogInformation("Assigning Admin role to the admin user");
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                    */
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding the database");
            }
        }

        private static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create role '{roleName}': {string.Join(",", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}

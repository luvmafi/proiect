using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;
using System.Collections.Generic;
using proiect.Data;

namespace proiect.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Roles.Any())
                {
                    return;
                }
                context.Roles.AddRange(
                    new IdentityRole
                    { Id = "2c5e174e-3b0e-446f-86af483d56fd7210", Name = "Admin", NormalizedName = "Admin".ToUpper() },
                    new IdentityRole
                    { Id = "2c5e174e-3b0e-446f-86af483d56fd7212", Name = "User", NormalizedName = "User".ToUpper() }

                );
                var hasher = new PasswordHasher<ApplicationUser>();
                context.Users.AddRange(
                    new ApplicationUser
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdb0",
                        UserName = "admin@proiect.com",
                        EmailConfirmed = true,
                        NormalizedEmail = "ADMIN@PROIECT.COM",
                        Email = "admin@proiect.com",
                        NormalizedUserName = "ADMIN@PROIECT.COM",
                        PasswordHash = hasher.HashPassword(null, "Admin1!")
                    },
                    new ApplicationUser
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdb2",
                        UserName = "user@proiect.com",
                        EmailConfirmed = true,
                        NormalizedEmail = "USER@proiect.COM",
                        Email = "user@proiect.com",
                        NormalizedUserName = "USER@PROIECT.COM",
                        PasswordHash = hasher.HashPassword(null, "User1!")
                    }
    );

                context.UserRoles.AddRange(
                    new IdentityUserRole<string>
                    {
                        RoleId = "2c5e174e-3b0e-446f-86af483d56fd7210",

                        UserId = "8e445865-a24d-4543-a6c69443d048cdb0"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "2c5e174e-3b0e-446f-86af483d56fd7212",

                        UserId = "8e445865-a24d-4543-a6c69443d048cdb2"
                    }
                );

                context.SaveChanges();
            }
        }
    }

}
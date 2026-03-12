using AspNetHw13.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetHw13.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.Migrate();

            if (context.Users.Any())
            {
                return;
            }

            var users = new ApplicationUser[]
            {
                new ApplicationUser { UserName = "Admin", Email = "admin@test.com" },
                new ApplicationUser { UserName = "User", Email = "user@test.com" }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}

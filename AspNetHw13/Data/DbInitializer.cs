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
                new ApplicationUser { UserName = "User", Email = "user@test.com" },
                new ApplicationUser { UserName = "Alice", Email = "alice@test.com" },
                new ApplicationUser { UserName = "Bob", Email = "bob@test.com" },
                new ApplicationUser { UserName = "Charlie", Email = "charlie@test.com" },
                new ApplicationUser { UserName = "David", Email = "david@test.com" },
                new ApplicationUser { UserName = "Eve", Email = "eve@test.com" },
                new ApplicationUser { UserName = "Frank", Email = "frank@test.com" },
                new ApplicationUser { UserName = "Grace", Email = "grace@test.com" },
                new ApplicationUser { UserName = "Heidi", Email = "heidi@test.com" },
                new ApplicationUser { UserName = "Ivan", Email = "ivan@test.com" },
                new ApplicationUser { UserName = "Judy", Email = "judy@test.com" },
                new ApplicationUser { UserName = "Kevin", Email = "kevin@test.com" },
                new ApplicationUser { UserName = "Laura", Email = "laura@test.com" },
                new ApplicationUser { UserName = "Mike", Email = "mike@test.com" }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}

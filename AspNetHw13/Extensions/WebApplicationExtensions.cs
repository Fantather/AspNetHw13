using AspNetHw13.Data;
using Microsoft.EntityFrameworkCore;

namespace AspNetHw13.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void SeedDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ApplicationDbContext>();
            DbInitializer.Initialize(context);
        }
    }
}
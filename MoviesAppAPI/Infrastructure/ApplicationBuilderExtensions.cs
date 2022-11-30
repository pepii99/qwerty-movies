using Microsoft.EntityFrameworkCore;
using MoviesAppAPI.Data;

namespace MoviesAppAPI.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<QwertyDbContext>();

            dbContext.Database.Migrate();
        }
    }
}

namespace MoviesAppAPI
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using MoviesAppAPI.Data;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder
                .Configuration
                .GetConnectionString("DefaultConnection") ?? 
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder
                .Services
                .AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(connectionString));

            builder
                .Services
                .AddDatabaseDeveloperPageExceptionFilter();

            builder
                .Services
                .AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            //app.MapControllers(endpoints => { endpoints.MapControllers(); });

            //app.MapRazorPages();

            app.Run();
        }
    }
}
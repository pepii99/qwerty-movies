namespace MoviesAppAPI
{
    using Microsoft.EntityFrameworkCore;
    using MoviesAppAPI.Data;
    using MoviesAppAPI.Helpers;
    using MoviesAppAPI.Infrastructure;
    using QwertyAPI.Infrastructure;
    using QwertyAPI.Features.Identity;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;

            // Add services to the container.
            var connectionString = builder
                .Configuration
                .GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services
                .AddDbContext<QwertyDbContext>(options => options
                .UseSqlServer(connectionString))
                .AddIdentity()
                .AddDatabaseDeveloperPageExceptionFilter()
                .AddCors()
                .AddControllers();           

            services
                .Configure<AppSettings>(builder
                .Configuration
                .GetSection("ApplicationSettings"));

            services.AddScoped<IIdentityService, IdentityService>();

            //

            var app = builder.Build();

            //Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseMigrationsEndPoint();
            }

            app.UseRouting()
                .UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader())
                .UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            }).ApplyMigrations();

            app.Run();
        }
    }
}
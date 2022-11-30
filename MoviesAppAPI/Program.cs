namespace MoviesAppAPI
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using MoviesAppAPI.Controllers;
    using MoviesAppAPI.Data;
    using MoviesAppAPI.Data.Models;
    using MoviesAppAPI.Helpers;
    using MoviesAppAPI.Infrastructure;
    using MoviesAppAPI.Services.Contracts;
    using MoviesAppAPI.Services;

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
                .UseSqlServer(connectionString));

            services
                .AddDatabaseDeveloperPageExceptionFilter();

            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 2;
                    options.User.RequireUniqueEmail = false;
                    
                })
                .AddEntityFrameworkStores<QwertyDbContext>();

            services
                .Configure<AppSettings>(builder
                .Configuration
                .GetSection("ApplicationSettings"));

            //services.AddScoped<ApiController, IdentityController>();

            //builder.Services.AddControllersWithViews();
            services.AddCors();
            services.AddControllers();

            services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            //Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseMigrationsEndPoint();
            }

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.ApplyMigrations();

            app.Run("http://localhost:4900");
        }
    }
}
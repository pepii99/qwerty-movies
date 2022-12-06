using Microsoft.AspNetCore.Identity;
using MoviesAppAPI.Data.Models;
using MoviesAppAPI.Data;

namespace QwertyAPI.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
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

            return services;
        }

    }
}

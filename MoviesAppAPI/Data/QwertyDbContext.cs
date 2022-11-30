namespace MoviesAppAPI.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MoviesAppAPI.Data.Models;

    public class QwertyDbContext : IdentityDbContext<User>
    {
        public QwertyDbContext(DbContextOptions<QwertyDbContext> options)
            : base(options)
        {
        }
    }
}
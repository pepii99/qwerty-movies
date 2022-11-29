namespace MoviesAppAPI.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class QwertyDbContext : IdentityDbContext
    {
        public QwertyDbContext(DbContextOptions<QwertyDbContext> options)
            : base(options)
        {
        }
    }
}
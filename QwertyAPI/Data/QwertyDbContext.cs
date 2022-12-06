namespace MoviesAppAPI.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MoviesAppAPI.Data.Models;
    using QwertyAPI.Data.Models;
    using System.Reflection.Emit;

    public class QwertyDbContext : IdentityDbContext<User>
    {
        public QwertyDbContext(DbContextOptions<QwertyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Actor> Actors { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Character>()
                .HasMany(c => c.Movies)
                .WithMany(m => m.Characters);

            builder.Entity<Actor>()
                .HasOne(a => a.Character)
                .WithOne(c => c.Actor)
                .HasForeignKey<Character>(c => c.ActorId).OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
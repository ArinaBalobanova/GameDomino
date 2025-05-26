using Microsoft.EntityFrameworkCore;

namespace Domino
{
    /// <summary>
    /// класс бд
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Host=localhost;Port=5432;Database=Game;Username=postgres;Password=12345";
                optionsBuilder.UseNpgsql(connectionString,
                    o => o.MigrationsAssembly("GameDomino"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User", "public");
        }
    }
}
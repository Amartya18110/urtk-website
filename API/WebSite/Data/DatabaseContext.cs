using Microsoft.EntityFrameworkCore;
using WebSite.Domains;

namespace WebSite
{
    public class DatabaseContext : DbContext
    {
        public DbSet<NewsDomain> NewsDomain { get; set; }
        public DbSet<UserDomain> UserDomain { get; set; }
        public DbSet<AboutDomain> AboutDomains { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
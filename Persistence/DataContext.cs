using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Child> Children { get; set; }
        public DbSet<Present> Presents { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Child>().HasKey(x => x.Id);
            builder.Entity<Present>().HasKey(x => x.Id);
        }
    }
}
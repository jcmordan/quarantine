using Microsoft.EntityFrameworkCore;
using Quarantine.Core.Models;

namespace Quarantine.Data
{
    public class QuarantineDbContext : DbContext
    {
        public QuarantineDbContext(DbContextOptions<QuarantineDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}

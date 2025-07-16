using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ConversionAPI.Data
{
    public class ConversionDbContext : DbContext
    {
        public ConversionDbContext(DbContextOptions<ConversionDbContext> options)
            : base(options)
        {
        }

        public DbSet<ConversionHistory> ConversionHistories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
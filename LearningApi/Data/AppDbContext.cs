using LearningApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningApi.Data
{
    // ---------- DATA LAYER: EF Core database context ----------
    // Represents a session with the database and exposes tables as DbSet properties.
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
    }
}

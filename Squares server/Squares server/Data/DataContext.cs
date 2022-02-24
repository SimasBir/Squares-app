using Microsoft.EntityFrameworkCore;
using Squares_server.Models;

namespace Squares_server.Data
{
    public class DataContext : DbContext
    {
        public DbSet<PointModel> Points { get; set; }
        public DbSet<NamedList> NamedLists { get; set; }
        public DbSet<NamedListPoint> NamedListPoints { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NamedListPoint>().HasKey(bc => new { bc.NamedListId, bc.PointModelId });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Squares_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //modelBuilder.Entity<PointModel>().HasKey(bc => new { bc.xCoord, bc.yCoord});
        }
    }
}

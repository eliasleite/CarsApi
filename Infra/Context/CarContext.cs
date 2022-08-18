using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Maker> Makers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {      
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

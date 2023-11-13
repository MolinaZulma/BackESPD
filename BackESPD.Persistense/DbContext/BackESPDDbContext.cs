using BackESPD.Domain.BaseEntity;
using BackESPD.Domain.Entities;
using BackESPD.Persistense.Seeds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BackESPD.Persistense.DbContext
{
    public class BackESPDDbContext : IdentityDbContext<User>
    {
        public BackESPDDbContext(DbContextOptions<BackESPDDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public virtual DbSet<ActivityLogsForm> ActivityLogsForm { get; set; }
        public virtual DbSet<DamageReport> DamageReport { get; set; }
        public virtual DbSet<Plant> Plants { get; set; }
        public virtual DbSet<FormatPTAPForm> FormatPTAPForm { get; set;}
        public virtual DbSet<JarFormatForm> JarFormatForm { get; set; }
        public virtual DbSet<SampleForm> SampleForm { get; set; }
        public virtual DbSet<WaterControlForm> WaterControlForm { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}

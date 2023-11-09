using BackESPD.Domain.Entities;
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
        public virtual DbSet<FormatPTAPForm> FormatPTAPForm { get; set;}
        public virtual DbSet<Plant> Plants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}

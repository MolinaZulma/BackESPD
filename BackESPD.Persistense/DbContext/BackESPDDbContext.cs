using BackESPD.Application.Interfaces;
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
        private readonly IDateTimeService _dateTimeService;

        public BackESPDDbContext(DbContextOptions<BackESPDDbContext> options, IDateTimeService dateTimeService) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTimeService = dateTimeService;
        }

        public virtual DbSet<ActivityLogsForm> ActivityLogsForm { get; set; }
        public virtual DbSet<DamageReport> DamageReport { get; set; }
        public virtual DbSet<Plant> Plants { get; set; }
        public virtual DbSet<FormatPTAPForm> FormatPTAPForm { get; set;}
        public virtual DbSet<JarFormatForm> JarFormatForm { get; set; }
        public virtual DbSet<SampleForm> SampleForm { get; set; }
        public virtual DbSet<WaterControlForm> WaterControlForm { get; set; }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTimeService.NowUtc;
                        //entry.Entity.CreatedBy = "admin";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = _dateTimeService.NowUtc;
                        //entry.Entity.LastModifiedBy = "admin";
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}

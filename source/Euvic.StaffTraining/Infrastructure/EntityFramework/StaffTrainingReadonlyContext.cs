using Euvic.StaffTraining.Domain.Views;
using Euvic.StaffTraining.Infrastructure.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Euvic.StaffTraining.Infrastructure.EntityFramework
{
    internal class StaffTrainingReadonlyContext : DbContext
    {
        public const string Schema = "dbo";

        public StaffTrainingReadonlyContext(DbContextOptions<StaffTrainingReadonlyContext> options)
            : base(options)
        {
        }

        DbSet<AttendeeSummary> AttendeesSummary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -- Single registration
            modelBuilder.ApplyConfiguration(new AttendeesSummaryConfigurations());
        }
    }
}

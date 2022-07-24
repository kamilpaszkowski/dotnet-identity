using Euvic.StaffTraining.Domain;
using Euvic.StaffTraining.Infrastructure.EntityFramework.Configurations.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Euvic.StaffTraining.Infrastructure.EntityFramework.Configurations
{
    internal class TrainingAttendeeStatusesConfiguration : IEntityTypeConfiguration<TrainingAttendeeStatus>
    {
        public void Configure(EntityTypeBuilder<TrainingAttendeeStatus> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(TrainingAttendeeStatusesSeed.GetSeed());
        }
    }
}

using Euvic.StaffTraining.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Euvic.StaffTraining.Infrastructure.EntityFramework.Configurations
{
    internal class TrainingAttendeeConfiguration : IEntityTypeConfiguration<TrainingAttendee>
    {
        public void Configure(EntityTypeBuilder<TrainingAttendee> builder)
        {
            builder.HasKey(x => new { x.TrainingId, x.AttendeeId });

            builder.HasOne(x => x.Training)
                .WithMany(x => x.Attendees)
                .HasForeignKey(x => x.TrainingId);

            builder.HasOne(x => x.Attendee)
             .WithMany(x => x.Trainings)
             .HasForeignKey(x => x.AttendeeId);

            builder.HasOne(x => x.Status)
             .WithMany()
             .HasForeignKey(x => x.StatusId);
        }
    }
}

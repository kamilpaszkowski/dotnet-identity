using Euvic.StaffTraining.Domain.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Euvic.StaffTraining.Infrastructure.EntityFramework.Configurations
{
    internal class AttendeesSummaryConfigurations : IEntityTypeConfiguration<AttendeeSummary>
    {
        public void Configure(EntityTypeBuilder<AttendeeSummary> builder)
        {
            builder.HasNoKey();
            builder.ToView("dbo.AttendeeSummary");
        }
    }
}

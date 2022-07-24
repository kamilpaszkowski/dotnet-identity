using Euvic.StaffTraining.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Euvic.StaffTraining.Infrastructure.EntityFramework.Configurations
{
    internal class TechnologyConfiguration : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Name)
                 .HasMaxLength(100)
                 .IsRequired();

            builder.Property(x => x.Scope).HasConversion(
              v => v.ToString(),
              v => (TechnologyScope)Enum.Parse(typeof(TechnologyScope), v));
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leaves.Leave.Infrastucture.Configuratons;

public class LeaveConfiguration : IEntityTypeConfiguration<Leaves.Domain.Leave>
{
    public void Configure(EntityTypeBuilder<Leaves.Domain.Leave> builder)
    {
        builder.ToTable("Leaves");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.PersonelId)
            .IsRequired();

        builder.Property(x => x.StartedDate)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(x => x.EndedDate)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<int>()
            .IsRequired();
    }
}
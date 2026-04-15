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
            .IsRequired();

        builder.Property(x => x.EndedDate)
            .IsRequired();
        
        builder.Property(x => x.Status).IsRequired();
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Approval.Approval.Infrastucture.Configuration;

public class ApprovalConfiguration : IEntityTypeConfiguration<Domain.Approval>
{
    public void Configure(EntityTypeBuilder<Domain.Approval> builder)
    {
        builder.ToTable("Approvals");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.LeaveId).IsRequired();

        builder.Property(x => x.PersonelId).IsRequired();

        builder.Property(x => x.ManagerId).IsRequired();

        builder.Property(x => x.Status).IsRequired();

        builder.Property(x => x.RejectionReason)
            .HasMaxLength(500);

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("date");
    }
}
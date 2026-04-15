using Microsoft.EntityFrameworkCore;

namespace Approval.Approval.Infrastucture.Context;

public class ApprovalDbContext(DbContextOptions<ApprovalDbContext> options):DbContext(options)
{
    public DbSet<Domain.Approval> Approvals { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApprovalDbContext).Assembly);
    }
}
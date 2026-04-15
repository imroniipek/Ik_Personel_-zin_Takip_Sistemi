using Microsoft.EntityFrameworkCore;

namespace Personel.Personel.Infrastucture.Context;

public class PersonelDbContext(DbContextOptions<PersonelDbContext> options):DbContext(options)
{
    public DbSet<Domain.Personel> personels { get; set; }
    
    public DbSet<Domain.Department> departments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonelDbContext).Assembly);
    }
}
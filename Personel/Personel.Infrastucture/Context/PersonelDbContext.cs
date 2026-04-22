using Microsoft.EntityFrameworkCore;

namespace Personel.Personel.Infrastucture.Context;

public class PersonelDbContext(DbContextOptions<PersonelDbContext> options):DbContext(options)
{
    public DbSet<Domain.Personel> Personels { get; set; }
    
    public DbSet<Domain.Department> Departments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonelDbContext).Assembly);
    }
}
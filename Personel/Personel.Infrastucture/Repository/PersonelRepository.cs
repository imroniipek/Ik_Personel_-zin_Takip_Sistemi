using Microsoft.EntityFrameworkCore;
using Personel.Personel.Application.Abstraction;
using Personel.Personel.Infrastucture.Context;

namespace Personel.Personel.Infrastucture.Repository;

public class PersonelRepository(PersonelDbContext context) : IPersonelRepository
{
    public async Task<Domain.Personel?> GetPersonelByIdAsync(int personelId)
    {
        return await context.personels.FindAsync(personelId);
    }

    public async Task<Domain.Personel> CreateNewPersonelAsync(Domain.Personel personel)
    {
        var entityEntry = await context.personels.AddAsync(personel);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public Task<List<Domain.Personel>> GetAllPersonelsAsync()=>context.personels.AsNoTracking().Include(x => x.Department).ToListAsync();
    
}
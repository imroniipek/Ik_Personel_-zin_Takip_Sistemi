using Microsoft.EntityFrameworkCore;
using Personel.Personel.Application.Abstraction;
using Personel.Personel.Domain;
using Personel.Personel.Infrastucture.Context;

namespace Personel.Personel.Infrastucture.Repository;

public class DepartmentRepository(PersonelDbContext context) : IDepartmentRepository
{
    public async Task<Department> CreateNewDepartmentAsync(Department department)
    {
        var entityEntry = await context.departments.AddAsync(department);

        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }
    
    public async Task<List<Domain.Personel>> GetPersonelsByManagerIdAsync(int managerId)
    {
        var department = await context.departments
            .Include(x => x.Personels)
            .FirstOrDefaultAsync(x => x.ManagerId == managerId);

        return department.Personels.ToList();
    }
}
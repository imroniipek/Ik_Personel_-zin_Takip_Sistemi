using Personel.Personel.Domain;

namespace Personel.Personel.Application.Abstraction;

public interface IDepartmentRepository
{
    Task<Department> CreateNewDepartmentAsync(Department department);

    Task<List<Domain.Personel>> GetPersonelsByManagerIdAsync(int managerId);
}
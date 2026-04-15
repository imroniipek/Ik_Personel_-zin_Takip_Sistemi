namespace Personel.Personel.Application.Abstraction;

public interface IPersonelRepository
{

    Task<Domain.Personel?> GetPersonelByIdAsync(int personelId);

    Task<Domain.Personel> CreateNewPersonelAsync(Domain.Personel personel);

    Task<List<Domain.Personel>> GetAllPersonelsAsync();
}
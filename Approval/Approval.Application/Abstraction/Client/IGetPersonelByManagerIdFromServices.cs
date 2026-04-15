using Refit;
namespace Approval.Approval.Application.Abstraction.Client;

public interface IGetPersonelByManagerIdFromServices
{
    [Get("api/getPersonelByManagerId")]
    Task<List<Personel.Personel.Domain.Personel>> GetPersonelByManagerId([AliasAs("managerId")] int managerId);
}
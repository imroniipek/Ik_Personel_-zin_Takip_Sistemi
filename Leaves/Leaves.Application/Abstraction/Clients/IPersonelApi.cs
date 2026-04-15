using Refit;
using Shared.Dtos;

namespace Leaves.Leaves.Application.Abstraction.Clients;

public interface IPersonelApi
{
    [Get("/api/personels/for-leave/{personelId}")]
    Task<PersonelInfoDto> GetThePersonelHire([AliasAs("personelId")] int personelId);
}
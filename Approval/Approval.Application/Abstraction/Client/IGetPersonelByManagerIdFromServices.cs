using Refit;
using Shared.Dtos;
using Shared.ServiceResult;

namespace Approval.Approval.Application.Abstraction.Client;

public interface IGetPersonelByManagerIdFromServices
{
    [Get("/api/getPersonelByManagerId")]
    Task<ServiceResult<List<PersonelIdDto>>> GetPersonelByManagerId([AliasAs("managerId")] int managerId);
}
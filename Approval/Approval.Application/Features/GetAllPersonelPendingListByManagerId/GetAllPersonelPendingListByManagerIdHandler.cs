using System.Net;
using Approval.Approval.Application.Abstraction.Client;
using Leaves.Leaves.Domain;
using MediatR;
using Shared.ServiceResult;

namespace Approval.Approval.Application.Features.GetAllPersonelPendingListByManagerId;

public class GetAllPersonelPendingListByManagerIdHandler(IGetPersonelByManagerIdFromServices managerIdFromServices,IGetPendingListByPersonelId pendingListService):IRequestHandler<GetAllPersonelPendingListByManagerId,ServiceResult<List<Leave>>>
{
    public async Task<ServiceResult<List<Leave>>> Handle(GetAllPersonelPendingListByManagerId request, CancellationToken cancellationToken)
    {
        var personelList = await managerIdFromServices.GetPersonelByManagerId(request.ManagerId);

        if (personelList is null || !personelList.Any())
        {
            return ServiceResult<List<Leave>>.Error(
                "Personeller bulunamadı",
                "Bu manager'a bağlı personel bulunamadı.",
                HttpStatusCode.NotFound
            );
        }
        var leaveList=await pendingListService.GetPendingLeaveListByListPersonelIdDto(personelList);

        return ServiceResult<List<Leave>>.SuccessOk(leaveList);
    }
}
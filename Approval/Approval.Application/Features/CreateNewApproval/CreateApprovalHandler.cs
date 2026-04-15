using Approval.Approval.Application.Abstraction.Client;
using Approval.Approval.Domain;
using MediatR;
using System.Net;

namespace Approval.Approval.Application.Features.CreateNewApproval;

public class CreateApprovalHandler(
    IGetPersonelByManagerIdFromServices managerIdFromServices,
    IGetLeaveListForApproval leaveListForApproval
) : IRequestHandler<CreateApproval, ServiceResult<CreateApprovalResponse>>
{
    public async Task<ServiceResult<CreateApprovalResponse>> Handle(
        CreateApproval request,
        CancellationToken cancellationToken)
    {
        var personelIdList = await managerIdFromServices.GetPersonelByManagerId(request.ManagerId);

        if (personelIdList is null || !personelIdList.Any())
        {
            return ServiceResult<CreateApprovalResponse>.Error(
                "Personeller bulunamadı",
                "Bu manager'a bağlı personel bulunamadı.",
                HttpStatusCode.NotFound
            );
        }
        

        var leaveList = await leaveListForApproval.GetLeaveListForApproval(new (personelIdList));

        if (leaveList is null || !leaveList.Any())
        {
            return ServiceResult<CreateApprovalResponse>.Error(
                "İzin bulunamadı",
                "Onay bekleyen izin bulunamadı.",
                HttpStatusCode.NotFound
            );
        }

        var selectedLeave = leaveList.FirstOrDefault(x => x.PersonelId == request.PersonelId);

        if (selectedLeave is null)
        {
            return ServiceResult<CreateApprovalResponse>.Error(
                "İzin bulunamadı",
                "Bu personele ait onay bekleyen izin bulunamadı.",
                HttpStatusCode.NotFound
            );
        }


        var newApproval = new Domain.Approval
        {
            LeaveId = selectedLeave.Id,
            PersonelId = request.PersonelId,
            ManagerId=request.ManagerId,
            Status=request.Status,
            CreatedAt = DateOnly.FromDateTime(DateTime.Now),
            RejectionReason = request.RejectReason
        };

        var response = new CreateApprovalResponse(
            selectedLeave.PersonelId,
            selectedLeave.Id,
            ApprovalStatus.Pending
        );

        return ServiceResult<CreateApprovalResponse>.SuccessOk(response);
    }
}
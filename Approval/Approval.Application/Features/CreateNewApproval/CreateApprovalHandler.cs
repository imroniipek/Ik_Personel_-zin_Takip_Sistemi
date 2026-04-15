using System.Net;
using Approval.Approval.Application.Abstraction.Client;
using Approval.Approval.Application.Abstraction.Repository;
using MediatR;
using Refit;
using Shared.Dtos;

namespace Approval.Approval.Application.Features.CreateNewApproval;

public class CreateApprovalHandler(
    IGetPersonelByManagerIdFromServices managerIdFromServices,
    IGetLeaveListForApproval leaveListForApproval,
    IApprovalRepository repository,
    IPutLeaveAfterApproval putLeaveAfterApproval
) : IRequestHandler<CreateApproval, ServiceResult<CreateApprovalResponse>>
{
    public async Task<ServiceResult<CreateApprovalResponse>> Handle(
        CreateApproval request,
        CancellationToken cancellationToken)
    {
        Domain.Approval? createdApproval=null;

        try
        {
            var personelList = await managerIdFromServices.GetPersonelByManagerId(request.ManagerId);

            if (!personelList.Any())
            {
                return ServiceResult<CreateApprovalResponse>.Error(
                    "Personeller bulunamadı",
                    "Bu manager'a bağlı personel bulunamadı.",
                    HttpStatusCode.NotFound
                );
            }

            var personelIds = personelList.Select(x => x.PersonelId).ToList();

            var leaveList = await leaveListForApproval.GetLeaveListForApproval(personelIds);

            if (!leaveList.Any())
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
                ManagerId = request.ManagerId,
                Status = request.Status,
                CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                RejectionReason = request.RejectReason
            };

            await repository.CreateApproval(newApproval);
            
            createdApproval = await repository.CreateApproval(newApproval);

            var updatedLeaveDto = new LeaveDto(
                selectedLeave.Id,
                selectedLeave.PersonelId,
                request.Status,
                selectedLeave.StartedDate,
                selectedLeave.EndedDate
            );

            await putLeaveAfterApproval.UpdateTheLeave(selectedLeave.Id, updatedLeaveDto);

            return ServiceResult<CreateApprovalResponse>.SuccessOk(
                new CreateApprovalResponse(
                    request.PersonelId,
                    selectedLeave.Id,
                    request.Status
                )
            );
        }
        catch (ApiException ex)
        {
            if (createdApproval != null)
            {
                await repository.DeleteApproval(createdApproval.Id);
            }
            return ServiceResult<CreateApprovalResponse>.ErrorFromProblemDetails(ex);
        }
        catch (Exception ex)
        {
            if (createdApproval != null) 
            {
                await repository.DeleteApproval(createdApproval.Id);
            }
            return ServiceResult<CreateApprovalResponse>.Error(
                "Beklenmeyen hata",
                ex.Message,
                HttpStatusCode.InternalServerError
            );
        }
    }
}
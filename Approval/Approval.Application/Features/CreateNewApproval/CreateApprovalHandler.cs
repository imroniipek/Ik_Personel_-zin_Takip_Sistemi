using System.Net;
using Approval.Approval.Application.Abstraction.Client;
using Approval.Approval.Application.Abstraction.Repository;
using MediatR;
using Refit;
using Shared.Dtos;
using Shared.ServiceResult;

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
        Domain.Approval? createdApproval = null;

        try
        {
            Console.WriteLine("=== CREATE APPROVAL STARTED ===");
            Console.WriteLine($"ManagerId: {request.ManagerId}");
            Console.WriteLine($"PersonelId: {request.PersonelId}");
            Console.WriteLine($"Status: {request.Status}");

            var personelResult = await managerIdFromServices.GetPersonelByManagerId(request.ManagerId);
            Console.WriteLine("1- Personel service çağrısı başarılı");
            Console.WriteLine($"Personel count: {personelResult.Data?.Count}");

            if (personelResult.Data is null || !personelResult.Data.Any())
            {
                return ServiceResult<CreateApprovalResponse>.Error(
                    "Personeller bulunamadı",
                    "Bu manager'a bağlı personel bulunamadı.",
                    HttpStatusCode.NotFound
                );
            }

            var selectedPersonel = personelResult.Data
                .FirstOrDefault(x => x.PersonelId == request.PersonelId);

            if (selectedPersonel is null)
            {
                return ServiceResult<CreateApprovalResponse>.Error(
                    "Personel bulunamadı",
                    $"{request.PersonelId} id'li personel bu manager'a bağlı değil.",
                    HttpStatusCode.NotFound
                );
            }

            Console.WriteLine("2- Personel doğrulaması başarılı");

            var leaveResult = await leaveListForApproval.GetLeaveListForApproval(request.PersonelId);
            Console.WriteLine("3- Leave service çağrısı başarılı");
            Console.WriteLine($"Leave count: {leaveResult.Data?.Count}");

            if (leaveResult.Data is null || !leaveResult.Data.Any())
            {
                return ServiceResult<CreateApprovalResponse>.Error(
                    "İzin bulunamadı",
                    $"{request.PersonelId} personele ait onay bekleyen izin bulunamadı.",
                    HttpStatusCode.NotFound
                );
            }

            var selectedLeave = leaveResult.Data.FirstOrDefault();

            if (selectedLeave is null)
            {
                return ServiceResult<CreateApprovalResponse>.Error(
                    "İzin bulunamadı",
                    $"{request.PersonelId} personele ait uygun izin bulunamadı.",
                    HttpStatusCode.NotFound
                );
            }

            Console.WriteLine($"4- Seçilen LeaveId: {selectedLeave.Id}");

            var newApproval = new Domain.Approval
            {
                LeaveId = selectedLeave.Id,
                PersonelId = request.PersonelId,
                ManagerId = request.ManagerId,
                Status = request.Status,
                CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                RejectionReason = request.RejectReason
            };

            createdApproval = await repository.CreateApproval(newApproval);
            Console.WriteLine($"5- Approval oluşturuldu. ApprovalId: {createdApproval.Id}");

            var updatedLeaveDto = new LeaveDto(
                selectedLeave.Id,
                selectedLeave.PersonelId,
                request.Status,
                selectedLeave.StartedDate,
                selectedLeave.EndedDate
            );

            await putLeaveAfterApproval.UpdateTheLeave(selectedLeave.Id, updatedLeaveDto);
            Console.WriteLine("6- Leave update başarılı");

            Console.WriteLine("=== CREATE APPROVAL SUCCESS ===");

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
            Console.WriteLine("=== API EXCEPTION ===");
            Console.WriteLine($"StatusCode: {ex.StatusCode}");
            Console.WriteLine($"Message: {ex.Message}");
            Console.WriteLine($"Content: {ex.Content}");

            if (createdApproval != null)
            {
                await repository.DeleteApproval(createdApproval.Id);
                Console.WriteLine($"Rollback yapıldı. Silinen ApprovalId: {createdApproval.Id}");
            }

            return ServiceResult<CreateApprovalResponse>.ErrorFromProblemDetails(ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine("=== GENERAL EXCEPTION ===");
            Console.WriteLine($"Message: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");

            if (createdApproval != null)
            {
                await repository.DeleteApproval(createdApproval.Id);
                Console.WriteLine($"Rollback yapıldı. Silinen ApprovalId: {createdApproval.Id}");
            }

            return ServiceResult<CreateApprovalResponse>.Error(
                "Beklenmeyen hata",
                ex.Message,
                HttpStatusCode.InternalServerError
            );
        }
    }
}
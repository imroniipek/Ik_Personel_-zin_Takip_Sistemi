using System.Net;
using Leaves.Leaves.Application.Abstraction.Clients;
using Leaves.Leaves.Application.Abstraction.Repositories;
using MediatR;
using Shared;

namespace Leaves.Leaves.Application.Features.CreateLeave;

public class CreateLeaveCommandHandler(
    ILeaveRepository repository,
    IPersonelApi personelApi
) : IRequestHandler<CreateLeaveCommand, ServiceResult<CreateLeaveResponse>>
{
    public async Task<ServiceResult<CreateLeaveResponse>> Handle(
        CreateLeaveCommand request,
        CancellationToken cancellationToken)
    {
        if (request.EndedDate.Date < request.StartedDate.Date)
        {
            return ServiceResult<CreateLeaveResponse>.Error(
                "Invalid date range",
                "Bitiş tarihi başlangıç tarihinden önce olamaz.",
                HttpStatusCode.BadRequest
            );
        }

        var thePersonelHire = await personelApi.GetThePersonelHire(request.PersonelId);
        
        Console.WriteLine(thePersonelHire.PersonelId);
        
        Console.WriteLine(thePersonelHire.HireDate);

        if (thePersonelHire is null)
        {
            return ServiceResult<CreateLeaveResponse>.Error(
                "Personel not found",
                "İzin talebi oluşturulacak personel bulunamadı.",
                HttpStatusCode.NotFound
            );
        }

        var totalEntitledDays = CalculateLeaveDays(thePersonelHire.HireDate, DateTime.UtcNow);

        if (totalEntitledDays == 0)
        {
            return ServiceResult<CreateLeaveResponse>.Error(
                "Insufficient leave entitlement",
                "Çalışanın henüz yıllık izin hakkı oluşmamış.",
                HttpStatusCode.BadRequest
            );
        }

        var usedLeaveDays = await repository.GetAllLeavesByPersonelIdForTheOneYear(request.PersonelId);

        var requestedLeaveDays = (request.EndedDate.Date - request.StartedDate.Date).Days + 1;

        if (totalEntitledDays < usedLeaveDays + requestedLeaveDays)
        {
            var remainingDays = totalEntitledDays - usedLeaveDays;

            return ServiceResult<CreateLeaveResponse>.Error(
                "Insufficient leave entitlement",
                $"Çalışan en fazla {remainingDays} gün daha izin kullanabilir.",
                HttpStatusCode.BadRequest
            );
        }

        var leave = new Domain.Leave
        {
            PersonelId = request.PersonelId,
            StartedDate = request.StartedDate,
            EndedDate = request.EndedDate,
            Status = LeaveStatus.Pending
        };

        var createdLeave = await repository.AddTheLeave(leave);

        var theLeaveResponse = new CreateLeaveResponse(
            createdLeave.Id,
            createdLeave.PersonelId,
            createdLeave.StartedDate,
            createdLeave.EndedDate,
            createdLeave.Status
        );

        return ServiceResult<CreateLeaveResponse>.SuccessCreatedOk(
            theLeaveResponse,
            $"/api/leaves/{createdLeave.Id}"
        );
    }

    private int CalculateLeaveDays(DateTime hireDate, DateTime today)
    {
        var years = today.Year - hireDate.Year;

        if (hireDate.Date > today.AddYears(-years))
        {
            years--;
        }

        if (years < 1)
        {
            return 0;
        }

        if (years <= 5)
        {
            return 14;
        }

        return 20;
    }
}
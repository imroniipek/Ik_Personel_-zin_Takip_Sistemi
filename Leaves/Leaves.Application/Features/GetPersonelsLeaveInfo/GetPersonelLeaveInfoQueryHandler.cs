using Leaves.Leaves.Application.Abstraction.Clients;
using Leaves.Leaves.Application.Abstraction.Repositories;
using MediatR;
using Shared.ServiceResult;

namespace Leaves.Leaves.Application.Features.GetPersonelsLeaveInfo;

public class GetPersonelLeaveInfoQueryHandler(ILeaveRepository leaveRepository,IPersonelApi personelApi):IRequestHandler<GetpersonelLeaveInfoQuery,ServiceResult<GetPersonelLeaveInfoDto>>
{
    public async Task<ServiceResult<GetPersonelLeaveInfoDto>> Handle(GetpersonelLeaveInfoQuery request,
        CancellationToken cancellationToken)
    {
        var personelInfoDto = await personelApi.GetThePersonelHire(request.PersonelId);

        var leaveDays = CalculateLeaveDays(personelInfoDto.HireDate, DateTime.Today);

        if (leaveDays == 0)
        {
            var theDto = new GetPersonelLeaveInfoDto(request.PersonelId, 0, 0, 0);
            return ServiceResult<GetPersonelLeaveInfoDto>.SuccessOk(theDto);
        }

        var usedLeaveDays = await leaveRepository.UsedLeaveDays(request.PersonelId);

        var remainingDaysCount = leaveDays - usedLeaveDays;

        var newDto = new GetPersonelLeaveInfoDto(request.PersonelId, leaveDays, usedLeaveDays, remainingDaysCount);

        return ServiceResult<GetPersonelLeaveInfoDto>.SuccessOk(newDto);
    }

    private int CalculateLeaveDays(DateOnly hireDate, DateTime today)
    {
        var todayDate = DateOnly.FromDateTime(today);

        int years = todayDate.Year - hireDate.Year;

        if (todayDate < hireDate.AddYears(years))
        {
            years--;
        }

        if (years < 1)
            return 0;

        if (years <= 5)
            return 14;

        return 20;
    }
}
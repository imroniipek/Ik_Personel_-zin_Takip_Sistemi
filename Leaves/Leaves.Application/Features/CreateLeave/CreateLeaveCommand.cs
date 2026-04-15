using MediatR;

namespace Leaves.Leaves.Application.Features.CreateLeave;

public record CreateLeaveCommand(int PersonelId, DateTime StartedDate, DateTime EndedDate )
    : IRequest<ServiceResult<CreateLeaveResponse>>;
using MediatR;
using Shared.Dtos;

namespace Leaves.Leaves.Application.Features.UpdateLeave;

public record UpdateLeaveCommand(int LeaveId,LeaveDto LeaveDto):IRequest<ServiceResult>{}
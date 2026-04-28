using Leaves.Leaves.Application.Features.CreateLeave;
using Leaves.Leaves.Application.Features.GetAcceptedLeavesByPersonelId;
using Leaves.Leaves.Application.Features.GetLeavesForApproval;
using Leaves.Leaves.Application.Features.GetPendingLeavesByPersenolIdQuery;
using Leaves.Leaves.Application.Features.GetPersonelsLeaveInfo;
using Leaves.Leaves.Application.Features.UpdateLeave;

namespace Leaves.Leaves.Application.Extensions;

public static class LeavesExtensions
{
    public static WebApplication LeaveEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api");

        group.AddCreateLeaveEndpoint();

        group.AddUpdateLeaveEndpoint();

        group.AddGetPersonelLeaveInfoEndpoint();

        group.AddGetLeavesForApproval();

        group.AddGetAcceptedLeavesByPersonelIdQueryEndpoint();

        group.AddGetPendingLeavesByPersonelIdQueryEndpoint();
        
        return app;
    }
}
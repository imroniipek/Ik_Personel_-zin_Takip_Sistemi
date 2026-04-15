using Leaves.Leaves.Application.Features.CreateLeave;
namespace Leaves.Leaves.Application.Extensions;

public static class LeavesExtensions
{
    public static WebApplication LeaveEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api");

        group.AddCreateLeaveEndpoint();

        return app;
    }
}
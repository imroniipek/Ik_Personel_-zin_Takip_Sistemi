using Approval.Approval.Application.Features.CreateNewApproval;
using Leaves.Leaves.Application.Features.CreateLeave;

namespace Approval.Approval.Application;

public static class ApprovalExtension
{

    public static WebApplication AddAllExtension(this WebApplication app)
    {

        app.MapGroup("/app/Approval").AddCreateExtension();

        return app;
    }
}
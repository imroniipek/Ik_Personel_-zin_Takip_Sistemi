using System.Net;
using Shared.ServiceResult;
using Shared.ServiceResult.Extensions;

namespace Personel.Personel.Application.Features.Personel.CreatePersonel;

public class CreatePersonelValidation : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var theRequest = context.GetArgument<CreatePersonelCommand>(0);

        if (theRequest.HireDate > DateOnly.FromDateTime(DateTime.Now))
        {
            return ServiceResult.Error("Geçersiz değer", "Personel işe başlama tarihi ileri bir tarih olamaz", HttpStatusCode.BadRequest).ToResult();
        }
        
        if (string.IsNullOrWhiteSpace(theRequest.FirstName) || theRequest.FirstName.Length < 3)
        {
            return Results.BadRequest("Ad en az 2 karakter olmalıdır.");
        }
        if (string.IsNullOrWhiteSpace(theRequest.Email) || !theRequest.Email.Contains(".com")&&!theRequest.Email.Contains("@"))
        {
            return Results.BadRequest("Geçerli bir e-posta adresi giriniz.");
        }

        return await next(context);
    }
}
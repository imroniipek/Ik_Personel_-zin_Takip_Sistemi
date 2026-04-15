using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Refit;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;


public class ServiceResult
{
    public HttpStatusCode StatusCode { get; set; }
    
    public ProblemDetails? Fail { get; set; }

    public bool IsSuccess => Fail is null;


    public static ServiceResult SuccessAsNoContent()
    {
        return new ServiceResult
        {
            StatusCode = HttpStatusCode.NoContent,
        };
    }

    public static ServiceResult ErrorAsNoFound()
    {
        return new ServiceResult
        {
            StatusCode = HttpStatusCode.NotFound,

            Fail = new ProblemDetails()
            {
                Title = "Not Found Error",
                Detail = "The requested resource was not found"
            }
        };
    }

    public static ServiceResult Error(string title, string description, HttpStatusCode httpStatusCode)
    {
        return new ServiceResult
        {
            StatusCode = httpStatusCode,
            Fail = new ProblemDetails()
            {
                Title = title,
                Detail = description,
            }
        };
    }

    public static ServiceResult ErrorFromRefit(ApiException apiException)
    {
        
        //Burdaki apiException'ı soyle dusun once ilk servisten hata gelince ne oıldugunu yazıyoruz//
        
        
        /*
         *   exception.StatusCode   // HTTP status (404 vs)
             exception.Content      // API’den gelen JSON hata
             exception.Message      // Genel hata mesajı
         */
        
        if (apiException.Content is not null)
        {
            return new ServiceResult
            {
                StatusCode = apiException.StatusCode,

                Fail = new ProblemDetails()
                {
                    Title = apiException.Message
                }
            };
        }

        var theProblemDetails = JsonSerializer.Deserialize<ProblemDetails>(apiException.Content);

        return new ServiceResult
        {
            Fail = theProblemDetails,
            StatusCode = apiException.StatusCode,
        };

    }
    
}

public class ServiceResult<T>:ServiceResult
{
    public T? Data { get; set; }
    
    public string? UrlAsCreated { get; set; }

    public static ServiceResult<T> SuccessOk(T data)
    {
        return new ServiceResult<T>
        {
            StatusCode = HttpStatusCode.OK,
            Data = data
        };
    }
    public static ServiceResult<T> SuccessCreatedOk(T data,string url)
    {
        return new ServiceResult<T>
        {
            StatusCode = HttpStatusCode.Created,
            UrlAsCreated = url,
            Data = data
        };
    }

    public new static ServiceResult<T> ErrorFromProblemDetails(ApiException exception)
    {
        Console.WriteLine(exception.Content);

        if (exception.Content is null)
        {
            return new ServiceResult<T>
            {
                StatusCode = exception.StatusCode,

                Fail = new ProblemDetails()
                {
                    Title = exception.Message,
                },
            };
        }

        var theProblemDetails =
            JsonSerializer.Deserialize<ProblemDetails>(exception.Content);

        return new ServiceResult<T>()
        {
            Fail = theProblemDetails,
            StatusCode = exception.StatusCode,

        };
    }

    public new static ServiceResult<T> Error(ProblemDetails problemDetail, HttpStatusCode httpStatusCode)
    {
        return new ServiceResult<T>()
        {
            Fail = problemDetail,
            StatusCode = httpStatusCode
        };
    }

    public new static ServiceResult<T> Error(string title, string description, HttpStatusCode httpStatusCode)
    {
        return new ServiceResult<T>()
        {
            StatusCode = httpStatusCode,
            Fail = new ProblemDetails()
            {
                Title=title,
                Detail=description,
            }
        };
    }

    public new static ServiceResult<T> ErrorAsNotFound()
    {
        return new ServiceResult<T>()
        {
            StatusCode = HttpStatusCode.NotFound,

            Fail = new ProblemDetails()
            {
                Title = "Not Found Error",
                Detail = $"The {typeof(T).Name} was not found",
            }

        };
    }
    
    

    public new static ServiceResult ErrorFromValidation(IDictionary<string, object?> errors)
    {
        var problemDetails = new ProblemDetails
        {
            Title = "Validation Error Occured",
            Detail = "Please check these properties for more details"
        };

        foreach (var error in errors)
        {
            problemDetails.Extensions.Add(error.Key, error.Value);
        }

        return new ServiceResult
        {
            StatusCode = HttpStatusCode.BadRequest,
            Fail = problemDetails
        };
    }


}
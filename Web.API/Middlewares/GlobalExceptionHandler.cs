using Application.Data;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using ApiException = Application.Data.Exceptions.ApiException;

namespace Estudante.API.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var logger = httpContext.RequestServices.GetService<ILogger<GlobalExceptionHandler>>();

        var response = new DefaultResponse<object>();
        response.Success = false;
        response.Data = null;
        response.StatusCode = StatusCodes.Status400BadRequest;

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        if (exception is ApiException applicationException)
        {
            httpContext.Response.StatusCode = applicationException.StatusCode;
            response.StatusCode = applicationException.StatusCode;
            response.Message = exception.Message;
        }
        else if (exception is ValidationException validationException)
        {
            var errors = validationException.Errors
                .Select(x => new
                {
                    property = x.PropertyName,
                    error = x.ErrorMessage
                });

            response.Errors = errors;
        }

        if (logger is not null)
            logger.LogError(exception, "ERRO CAPTURADO NO MIDDLEWARE GLOBAL");

        await httpContext.Response.WriteAsJsonAsync(response);

        return true;
    }
}
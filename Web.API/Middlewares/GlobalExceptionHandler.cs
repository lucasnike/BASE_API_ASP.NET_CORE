using Application.Data;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using ApiException = Application.Data.Exceptions.ApiException;

namespace Estudante.API.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
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

        await httpContext.Response.WriteAsJsonAsync(response);

        return true;
    }
}
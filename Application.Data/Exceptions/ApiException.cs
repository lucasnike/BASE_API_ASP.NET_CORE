namespace Application.Data.Exceptions;

using Microsoft.AspNetCore.Http;

public class ApiException : Exception
{
    public ApiException()
    {
    }

    public ApiException(string? message) : base(message)
    {
    }

    public ApiException(string? message, ApiException? innerException) : base(message, innerException)
    {
    }

    public virtual int StatusCode { get; set; } = StatusCodes.Status400BadRequest;
    
}
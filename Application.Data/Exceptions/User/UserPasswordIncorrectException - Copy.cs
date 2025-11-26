namespace Application.Data.Exceptions.User;

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

public class UserRefreshTokenInvalidException : ApiException
{
    public UserRefreshTokenInvalidException()
    {
    }

    public UserRefreshTokenInvalidException(string? message) : base(message)
    {
    }

    public override int StatusCode { get => StatusCodes.Status403Forbidden; set => base.StatusCode = value; }
}

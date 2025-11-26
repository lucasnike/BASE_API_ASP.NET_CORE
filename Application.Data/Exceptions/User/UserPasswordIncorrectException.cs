namespace Application.Data.Exceptions.User;

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

public class UserPasswordIncorrectException : ApiException
{
    public UserPasswordIncorrectException()
    {
    }

    public UserPasswordIncorrectException(string? message) : base(message)
    {
    }

    public override int StatusCode { get => StatusCodes.Status403Forbidden; set => base.StatusCode = value; }
}

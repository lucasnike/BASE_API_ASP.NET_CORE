namespace Application.Data.Exceptions.User;

using Microsoft.AspNetCore.Http;

public class UserNotFoundException : ApiException
{
    public override int StatusCode { get => StatusCodes.Status404NotFound; set => base.StatusCode = value; }
}

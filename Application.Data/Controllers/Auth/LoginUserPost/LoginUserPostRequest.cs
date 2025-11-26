namespace Application.Data.Controllers.Auth.LoginUserPost;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

public class LoginUserPostRequest : IRequest<DefaultResponse<LoginUserPostResponse>>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

namespace Application.Data.Controllers.Auth.LoginUserPost;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

public class LoginUserRefreshTokenPostRequest : IRequest<DefaultResponse<LoginUserRefreshTokenPostResponse>>
{
    public string RefreshToken { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}
